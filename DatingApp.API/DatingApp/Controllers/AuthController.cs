using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Dtos;
using DatingApp.Models;
using DatingApp.Repository;
using DatingApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(UserForRegisterDto UserForRegisterDto)
        {

            UserForRegisterDto.UserName = UserForRegisterDto.UserName.ToLower();

            if( await _repo.UserExists(UserForRegisterDto.UserName))
            {
                return BadRequest("User already exists.");


            };

            var userToCreate = new User
            {
                Username = UserForRegisterDto.UserName
            };

            var createdUser = await _repo.Register(userToCreate, UserForRegisterDto.Password);

            return StatusCode(201);
        }
    }
}