using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImageAfricaProject.Dto;
using ImageAfricaProject.Helpers;
using ImageAfricaProject.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ImageAfricaProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ValidateModel]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateUser([FromBody] JsonPatchDocument<UpdateUserDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }
            var checkIfUserExists = await _userRepository.GetCurrentUserAsync();
            if (checkIfUserExists == null)
            {
                return BadRequest();
            }
            var userToPatch = _mapper.Map<UpdateUserDto>(checkIfUserExists);
            patchDocument.ApplyTo(userToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TryValidateModel(userToPatch);
            //because the first ModelState.IsValid only checks if the patchDocument is valid
            //checking again after tryValidateModel state checks if the userToPatch is in its valid model state 
            //ie following data annotation rules
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _mapper.Map(userToPatch, checkIfUserExists);

            var saveChanges = await _userRepository.Save();
            if (!saveChanges)
            {
                return StatusCode(500, "An error occured while handling your request.");
            }
            return NoContent();
        }
    }
}