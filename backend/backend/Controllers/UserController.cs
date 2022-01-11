using backend.Models;
using backend.Persistence;
using backend.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ApiController
    {
        private readonly IUserProvider _userProvider;
        public UserController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserOut))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] UserIn userIn)
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = userIn.FirstName,
                LastName = userIn.LastName
            };

            var res = await _userProvider.CreateUserAsync(user);
            return Ok(res);
        }

        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserOut))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            var res = await _userProvider.UpdateUserAsync(user);
            return Ok(res);
        }

        [HttpGet("{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserOut))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(Guid userId)
        {
            var res = await _userProvider.GetUserAsync(userId);
            return Ok(res);
        }

        [HttpDelete("{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserOut))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var res = await _userProvider.DeleteUserAsync(userId);
            return Ok(res);
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserOut>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var res = _userProvider.GetUsersAsync();
            return Ok(res);
        }

        [HttpDelete("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete()
        {
            await _userProvider.DeleteUsersAsync();
            return Ok();
        }
    }
}
