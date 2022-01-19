using backend.Models;
using backend.Persistence;
using backend.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
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
                LastName = userIn.LastName,
                Address = userIn.Address,
            };

            User dbUser = await _userProvider.CreateUserAsync(user);
            return Ok(new UserOut { 
                Id = dbUser.Id,
                Address = dbUser.Address,
                Base64Image = dbUser.Base64Image,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName
            });
        }

        [HttpPost("Image/{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserOut))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Upload(Guid userId, IFormFile image)
        {
            try
            {
                string extension = Path.GetExtension(image.FileName);

                if (image != null && image.Length > 0)
                {
                    string imagePath = Path.Combine(".\\Images", Guid.NewGuid().ToString() + extension);

                    User dbUser = await _userProvider.GetUserAsync(userId);

                    if (System.IO.File.Exists(dbUser.ImagePath))
                    {
                        System.IO.File.Delete(dbUser.ImagePath);
                    }


                    using (FileStream stream = new FileStream(imagePath, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }

                    dbUser.ImagePath = imagePath;
                    dbUser.Base64Image = $"data:image/{extension};base64," + Convert.ToBase64String(System.IO.File.ReadAllBytes(imagePath));
                    await _userProvider.UpdateUserAsync(dbUser);

                    return Ok(new UserOut
                    {
                        Id = dbUser.Id,
                        Address = dbUser.Address,
                        Base64Image = dbUser.Base64Image,
                        FirstName = dbUser.FirstName,
                        LastName = dbUser.LastName
                    });
                }
                else
                {
                    return BadRequest("No image uploaded");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("Image/{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetImageBase64(Guid userId)
        {
            User dbUser = await _userProvider.GetUserAsync(userId);

            if (dbUser == null)
                return BadRequest($"User with id '{userId}' not found!");

            return Ok(dbUser.Base64Image);
        }

        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserOut))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            User dbUser = await _userProvider.UpdateUserAsync(user);
            return Ok(new UserOut
            {
                Id = dbUser.Id,
                Address = dbUser.Address,
                Base64Image = dbUser.Base64Image,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName
            });
        }

        [HttpGet("{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserOut))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(Guid userId)
        {
            User dbUser = await _userProvider.GetUserAsync(userId);;
            return Ok(new UserOut
            {
                Id = dbUser.Id,
                Address = dbUser.Address,
                Base64Image = dbUser.Base64Image,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName
            });
        }

        [HttpDelete("{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserOut))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid userId)
        {
            User dbUser = await _userProvider.DeleteUserAsync(userId);
            return Ok(new UserOut
            {
                Id = dbUser.Id,
                Address = dbUser.Address,
                Base64Image = dbUser.Base64Image,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName
            });
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserOut>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            List<User> dbUsers = _userProvider.GetUsersAsync();
            List<UserOut> usersOut = dbUsers.Select(x => new UserOut
            {
                Id = x.Id,
                Address = x.Address,
                Base64Image = x.Base64Image,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();


            return Ok(usersOut);
        }

        [HttpDelete("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserOut>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete()
        {
            await _userProvider.DeleteUsersAsync();

            List<User> dbUsers = _userProvider.GetUsersAsync();
            List<UserOut> usersOut = dbUsers.Select(x => new UserOut
            {
                Id = x.Id,
                Address = x.Address,
                Base64Image = x.Base64Image,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();


            return Ok(usersOut);
        }
    }
}
