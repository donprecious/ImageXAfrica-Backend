using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Factories;
using Helpers;
using ImageAfricaProject.Dto;
using ImageAfricaProject.Dto.auth;
using ImageAfricaProject.Entities;
using ImageAfricaProject.Helpers;
using ImageAfricaProject.Repository;
using ImageAfricaProject.Services;
using ImageAfricaProject.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Providers;
using WebApi.Models;

namespace ImageAfricaProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ValidateModel]
    public class AuthController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IMapper _mapper;
        private IEmailService _emailService;
        private IConfiguration _config;
        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtFactory jwtFactory,  IOptions<JwtIssuerOptions> jwtOptions, IMapper mapper, IUserRepository userRepository, IEmailService emailService, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtFactory = jwtFactory;
            _mapper = mapper;
            _userRepository = userRepository;
            _emailService = emailService;
            _config = config;
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
            _jwtOptions = jwtOptions.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthenticateModel model)
        {
            var identity = await GetClaimsIdentity(model.Email, model.Password);
            
            if (identity == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            //convert user to a user dto model and upload along side the request 
            var mappedUser = _mapper.Map<UserDto>(user);
            var roles = await _userManager.GetRolesAsync(user);
            var response = new
            {
                id=identity.Claims.Single(c=>c.Type=="id").Value,
                auth_token = await _jwtFactory.GenerateEncodedToken(model.Email, identity),
                expires_in = (int)_jwtOptions.ValidFor.TotalSeconds,
                roles = roles,
                user = mappedUser
            };
            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }

        
        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                // get the user to verifty
                var userToVerify = await _userManager.FindByNameAsync(userName);

                if (userToVerify != null)
                {
                    // check the credentials  
                    if (await _userManager.CheckPasswordAsync(userToVerify, password))
                    {
                        return await _jwtFactory.GenerateClaimsIdentity(userName,userToVerify.Id);
                    }
                }
            }
            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);

        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserDto model)
        {
            var mappedUser = _mapper.Map<ApplicationUser>(model);
            mappedUser.UserName = model.Email;
            var result = await _userManager.CreateAsync(mappedUser, model.Password);
            if (result.Succeeded)
            {
                return StatusCode(201, mappedUser);
            }
            else
            {
                foreach (var i in result.Errors)
                {
                    ModelState.AddModelError(i.Code.ToString(), i.Description);
                }
                 return BadRequest( ModelState);
            }
            return StatusCode(500, "server error");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _userRepository.GetCurrentUserAsync();
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(user);
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GoogleAuth([FromBody] GoogleLoginDto externalLogin)
        {
            var payLoad = await _userRepository.ValidateGooglePayLoad(externalLogin.IdToken);
            //var info = await _signInManager.GetExternalLoginInfoAsync();

            if (payLoad == null)
            {
                return Unauthorized("Please login, no provider found");
            }

            //  find user by email if he exists 
            var user = await _userManager.FindByEmailAsync(payLoad.Email);

            if (user != null)
            {
               
                if (payLoad.EmailVerified)
                {
                    user.EmailConfirmed = true;
                  await  _userRepository.Update(user);
                  await _userRepository.Save();
                }
                    var identity = await _jwtFactory.GenerateClaimsIdentity(user.UserName, user.Id);
                    var token = await _jwtFactory.GenerateEncodedToken(user.UserName, identity);
                    var mappedUser = _mapper.Map<UserDto>(user);
                    var roles = await _userManager.GetRolesAsync(user);
                    var response = new
                    {
                        id=identity.Claims.Single(c=>c.Type=="id").Value,
                        auth_token = token,
                        expires_in = (int)_jwtOptions.ValidFor.TotalSeconds,
                        roles = roles,
                        user = mappedUser
                    };
                    return Ok(response);
             

            }
            else
            {
                // no user found create a new one and set emailConfirm to true 

                var createdUser = await _userManager.CreateAsync(new ApplicationUser()
                {
                    Email = payLoad.Email,
                    FirstName = payLoad.GivenName,
                    LastName = payLoad.FamilyName,
                    UserName = payLoad.Email,
                    TwoFactorEnabled = true,
                    EmailConfirmed = true
                });

                if (createdUser.Succeeded)
                {
                    // sign in the user with a token and notify the user to update his password 
                    var newUser = await _userManager.FindByEmailAsync(payLoad.Email);
                    if (newUser == null) return BadRequest("unable to find this user, please try again");

                    var identity = await _jwtFactory.GenerateClaimsIdentity(newUser.UserName, newUser.Id);
                  
                    var mappedUser = _mapper.Map<UserDto>(newUser);
                    var roles = await _userManager.GetRolesAsync(newUser);
                    var response = new
                    {
                        id=identity.Claims.Single(c=>c.Type=="id").Value,
                        auth_token = await _jwtFactory.GenerateEncodedToken(newUser.UserName, identity),
                        expires_in = (int)_jwtOptions.ValidFor.TotalSeconds,
                        roles = roles,
                        user = mappedUser,
                        message = "success, please redirect user to setup his password"
                    };
                    return Ok(response);
                  
                }
            }

            return StatusCode(500, "something went wrong");

        } 

        
        [HttpGet("resend-confirmation")]
        public async Task<IActionResult> ResendConfirmationEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                NotFound(new
                {
                    status = "fail",
                    message = "invalid user email"
                });
            }

            if (user.EmailConfirmed)
            {
                return BadRequest(new
                {
                    status = "fail",
                    message = "email already confirmed"
                });
            }

            var callbackUrl = await GenerateToken(user, "confirmation", "ComfirmEmail");

            await _emailService.Send(user.Email, "Email Confirmation",
                   $"<p>Email confirmation <a href={callbackUrl}>Link</a></p>");

            return Ok(new
            {
                status = "success",
                message = "email confirmation link has been sent"
            });
        }

        private async Task<string> GenerateToken(ApplicationUser user, string tokenType, string method)
        {
            var token = "";
            if (tokenType == "confirmation")
            {
                token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            }

            if (tokenType == "reset")
            {
                token = await _userManager.GeneratePasswordResetTokenAsync(user);
            }

            //token = HttpUtility.UrlEncode(token);

            var fontEndUrl = _config.GetSection("frontendUrl").Value;
            var url = $"{fontEndUrl}/auth/{method}/?userId={user.Email}&token={token}";
            return url;
        }

        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return BadRequest(new
                {
                    status = "fail",
                    message = "token is invalid or has expired"
                });
            }

            var user = await _userManager.FindByEmailAsync(userId);
            if (user == null)
            {
                return BadRequest(new
                {
                    status = "fail",
                    message = $"invalid user {userId}"
                });
            }

            if (user.EmailConfirmed)
            {
                return BadRequest(new
                {
                    status = "fail",
                    message = "email already confirmed"
                });
            }

            //token = HttpUtility.UrlDecode(token);

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return Ok(new ResponseDto()
                {
                    Status = ResponseStatus.Success,
                    Message = "confirmed successfully"
                });
            }

            return BadRequest(new
            {
                status = "fail",
                message = "token is invalid or has expired"
            });
        }

        [HttpPost("forgot")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);

            if (user == null)
            {
                return Ok(new
                {
                    status = "success",
                    message = "reset password link has been sent"
                });
            }

            if (!user.EmailConfirmed)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, new
                {
                    status = "fail",
                    message = "your email is not yet confirmed"
                });
            }

            var callbackUrl = await GenerateToken(user, "reset", "ResetPassword");

            await _emailService.Send(user.Email, "Password Reset",
                   $"<p>Password reset token <a href={callbackUrl}>Link</a></p>");

            return Ok(new
            {
                status = "success",
                message = "reset password link has been sent"
            });
        }

        [HttpPatch("reset")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            if (resetPasswordDto.UserId == null || resetPasswordDto.Token == null)
            {
                return BadRequest(new
                {
                    status = "fail",
                    message = "token is invalid or has expired"
                });
            }

            var user = await _userManager.FindByEmailAsync(resetPasswordDto.UserId);
            if (user == null)
            {
                return BadRequest(new
                {
                    status = "fail",
                    message = "token is invalid or has expired"
                });
            }

            var token = resetPasswordDto.Token;

            var update = await _userManager.ResetPasswordAsync(user, token, resetPasswordDto.Password);

            if (update.Succeeded)
            {
                return Ok(new
                {
                    status = "success",
                    message = "password was changed"
                });
            }

            return BadRequest(new
            {
                status = "error",
                message = "password not changed",
                errors = update.Errors
            });
        }

        [Authorize]
        [HttpPatch("Change-Password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var user = await _userRepository.GetCurrentUserAsync();
            if (user == null) return Unauthorized("User Not Authorized");

            var result = await _userManager.ChangePasswordAsync(user, changePasswordDto.CurrentPassword,
                changePasswordDto.NewPassword);

            if (result.Succeeded)
            {
                return Ok(new
                {
                    status = "success",
                    message = "password has been updated"
                });
            }

            return BadRequest(new
            {
                status = "error",
                message = "password not updated",
                errors = result.Errors
            });
        }

    }
}