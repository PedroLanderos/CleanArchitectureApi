using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using UserApi.Application.DTOs;
using UserApi.Application.Interfaces;
using UserApi.Application.Mappers;

namespace UserApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserInterface userInterface) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(UserDTO user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var getEnity = UserMapper.ToEntity(user);
            var response = await userInterface.AddUser(getEnity);

            if (response.Flag) return Ok(response);
            else return BadRequest(ModelState);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDTO>> GetUser(int userId)
        {
            var user = await userInterface.GetUserById(userId);
            if(user is null) return NotFound("user not found");

            var (_user, _) = UserMapper.FromEntity(user, null!);

            return _user is not null ? Ok(user) : NotFound("user not found");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<UserDTO>> DeleteUser(int userId)
        {
            if (userId < 0) return BadRequest("incorrect id");
            //find user by id
            var user = GetUser(userId);
            if (user is null) return NotFound("no user found");

            var response = await userInterface.DeleteUser(userId);
            if (response.Flag) return Ok(response);
            else return NotFound("user was not deleted");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserDTO>> UpdateUser(int userId, UserDTO user)
        {
            var getUser = await GetUser(userId);
            if (getUser is null) return NotFound("user not found");

            if (!ModelState.IsValid) return BadRequest("user model was wrong");

            var userEntity = UserMapper.ToEntity(user);

            var response = await userInterface.UpdateUser(userId, userEntity);

            if (response.Flag) return Ok(response);
            else return NotFound("user was not updated");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await userInterface.GetAllUsers();
            if (!users.Any()) return NotFound("No users");

            var (_, usersList) = UserMapper.FromEntity(null, users);
            return usersList!.Any() ? Ok(usersList) : NotFound("no users found");
        }
    }
}
