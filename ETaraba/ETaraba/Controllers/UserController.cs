using AutoMapper;
using ETaraba.Domain.Models;
using ETaraba.DTOs.UserDTOs;
using ETaraba.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETaraba.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly IMapper _mapper;
        public UserController(UserManager<User> userManager, RoleManager<UserRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;   
        }
        [HttpGet]
        public async Task<IActionResult> GetUserByUserName(string username)
        {
            var userToFind = await _userManager.FindByNameAsync(username);
            return Ok(_mapper.Map<UserDTO>(userToFind));
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register( [FromBody] UserForCreationDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userExist = await _userManager.FindByNameAsync(user.UserName);
            if(userExist != null)
            {
                return BadRequest("User already exists");
            }
            var usertToCreate = new User
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ProfileImgSrc = user.ProfileImageSrc

            };
            var result = await _userManager.CreateAsync(usertToCreate, user.Password);
            var userToReturn = _mapper.Map<UserDTO>(usertToCreate);
            if (!result.Succeeded)
            {
                return BadRequest("Failed to create user");
            }        
            return Ok(userToReturn);
        }
    }
}
