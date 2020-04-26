using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImageAfricaProject.Dto.challenge;
using ImageAfricaProject.Entities;
using ImageAfricaProject.Repository;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ImageAfricaProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChallengeController : Controller
    {
        private IChallengeRepository _challengeRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public ChallengeController(IChallengeRepository challengeRepository, IMapper mapper, IUserRepository userRepository)
        {
            _challengeRepository = challengeRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        [HttpGet("{id}",Name = "GetChallenge")]
        public async Task<IActionResult> GetChallenge(int id)
        {
            try
            {
                var challenge = await _challengeRepository.GetChallenge(id);
                if (challenge == null)
                    return NotFound();

                var mapped = _mapper.Map<GetChallengeDto>(challenge);
                return Ok(mapped);
            }
            catch (Exception ex)
            {

                throw;
            }
            
            
        }
        [HttpGet]
        public async Task<IActionResult> GetActiveChallenges()
        {
            var challenges = await _challengeRepository.GetActiveChallenges();
            var mapped = _mapper.Map<IEnumerable<GetChallengeDto>>(challenges);
            return Ok(mapped);
        }
        [HttpGet]
        public async Task<IActionResult> GetExpiredChallenges()
        {
            var challenges = await _challengeRepository.GetExpiredChallenges();
            var mapped = _mapper.Map<IEnumerable<GetChallengeDto>>(challenges);
            return Ok(mapped);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateChallenge([FromBody] CreateChallengeDto createChallengeDto)
        {
            if (createChallengeDto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var challenge = _mapper.Map<Challenge>(createChallengeDto);
            var user = await _userRepository.GetCurrentUserAsync();
            challenge.CreatorUserId = user.Id;  
            await _challengeRepository.Create(challenge);
            var saveChanges = await _challengeRepository.Save();
            if (!saveChanges)
            {
                return StatusCode(500, "An error occured while handling your request.");
            }
            var challengeCreated = _mapper.Map<GetChallengeDto>(challenge);
            return CreatedAtRoute(nameof(GetChallenge), new { id = challengeCreated.Id }, challengeCreated);
        }
        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> UpdateChallenge(int id,[FromBody] JsonPatchDocument<UpdateChallengeDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }
            var challenge =await  _challengeRepository.GetChallenge(id);
            if (challenge == null)
            {
                return BadRequest();
            }
            var challengeToPatch = _mapper.Map<UpdateChallengeDto>(challenge);
            patchDocument.ApplyTo(challengeToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TryValidateModel(challengeToPatch);
            //because the first ModelState.IsValid only checks if the patchDocument is valid
            //checking again after tryValidateModel state checks if the challengeToPatch is in its valid model state 
            //ie following data annotation rules
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _mapper.Map(challengeToPatch, challenge);

            var user = await _userRepository.GetCurrentUserAsync();
            challenge.LastModifierUserId = user.Id;

            var saveChanges = await _challengeRepository.Save();
            if (!saveChanges)
            {
                return StatusCode(500, "An error occured while handling your request.");
            }
            return NoContent();

        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteChallenge(int id)
        {
            var challenge = await _challengeRepository.GetChallenge(id);
            if (challenge == null)
            {
                return NotFound();
            }
            _challengeRepository.DeleteChallenge(challenge);
            var user = await _userRepository.GetCurrentUserAsync();
            challenge.DeleterUserId = user.Id;
            var saveChanges = await _challengeRepository.Save();
            if (!saveChanges)
            {
                return StatusCode(500, "An error occured while handling your request.");
            }
            return NoContent();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> JoinChallenge(UserChallengeDto userChallengeDto)
        {
            if (userChallengeDto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var challenge = await _challengeRepository.GetChallenge(userChallengeDto.ChallengeId);
            if (challenge == null)
            {
                return NotFound();
            }
            var userChallenge = _mapper.Map<UserChallenge>(userChallengeDto);
            var user = await _userRepository.GetCurrentUserAsync();
            userChallenge.UserId = user.Id;
            await _challengeRepository.JoinChallenge(userChallenge);
            var saveChanges = await _challengeRepository.Save();
            if (!saveChanges)
            {
                return StatusCode(500, "An error occured while handling your request.");
            }
            var challengeJoined = _mapper.Map<GetChallengeDto>(challenge);
            return CreatedAtRoute(nameof(GetChallenge), new { id = challengeJoined.Id }, challengeJoined);
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> LeaveChallenge(int challengeId)
        {
            var challenge = await _challengeRepository.GetChallenge(challengeId);
            if (challenge == null)
            {
                return NotFound();
            }
            var user = await _userRepository.GetCurrentUserAsync();
            var userId = user.Id;
            var userChallenge = await _challengeRepository.GetUserChallenge(challenge.Id, userId);
            if (userChallenge == null)
            {
                return NotFound();
            }
            await _challengeRepository.LeaveChallenge(userChallenge);
            var saveChanges = await _challengeRepository.Save();
            if (!saveChanges)
            {
                return StatusCode(500, "An error occured while handling your request.");
            }
            return NoContent();
        }
    }
}