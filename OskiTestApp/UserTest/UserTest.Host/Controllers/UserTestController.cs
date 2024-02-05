﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UserTest.Host.Models.Dtos;
using UserTest.Host.Models.Requests;
using UserTest.Host.Services.Interfaces;

namespace UserTest.Host.Controllers
{
    [Route("usertest")]
    [ApiController]
    public class UserTestController : ControllerBase
    {
        private readonly IUserTestService _userTestService;
        public UserTestController(IUserTestService userTestService)
        {
            _userTestService = userTestService;
        }

        [HttpGet("getusertests")]
        [ProducesResponseType(typeof(IEnumerable<UserTestDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserTestsAsync([FromQuery] string userId, [FromQuery] bool isTestComleted)
        {
            var result = await _userTestService.GetUserTestsAsync(userId, isTestComleted);
            return Ok(result);
        }

        [HttpPost("addusertests")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddUserAsync([FromBody] AddUserTestRequest userTest)
        {
            await _userTestService.AddUserTestAsync(userTest);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUserTestAsync([FromBody] UpdateUserTestRequest userTest)
        {
            await _userTestService.UpdateUserTestAsync(userTest);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUserTestAsync([FromQuery] string userId, [FromQuery] int testId)
        {
            await _userTestService.DeleteUserTestAsync(userId, testId);
            return Ok();
        }
    }
}
