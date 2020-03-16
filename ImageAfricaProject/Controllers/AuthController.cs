using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Factories;
using Helpers;
using ImageAfricaProject.Dto;
using ImageAfricaProject.Entities;
using ImageAfricaProject.Helpers;
using ImageAfricaProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtFactory jwtFactory,  IOptions<JwtIssuerOptions> jwtOptions, IMapper mapper, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtFactory = jwtFactory;
            _mapper = mapper;
            _userRepository = userRepository;
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
            }r
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
                 return StatusCode(500, ModelState);
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
    }
}