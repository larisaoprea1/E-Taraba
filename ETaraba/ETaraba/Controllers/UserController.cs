using AutoMapper;
using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using ETaraba.DTOs.UserDTOs;
using ETaraba.Infrastructure;
using ETaraba.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ETaraba.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserController(UserManager<User> userManager,
            RoleManager<UserRole> roleManager,
            IMapper mapper,
            IUserRepository userRepository,
            IConfiguration configuration)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)) ;
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        [HttpGet]
        public async Task<IActionResult> GetUserByUserName(string username)
        {
            var userToFind = await _userManager.FindByNameAsync(username);
            return Ok(_mapper.Map<UserDTO>(userToFind));
        }
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var usersToGet = await _userRepository.GetUsersAsync();
            return Ok(_mapper.Map<IEnumerable<UserDTO>>(usersToGet));
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var userById = await _userRepository.GetUserAsync(userId);
            return Ok(_mapper.Map<UserDTO>(userById));
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register( [FromBody] RegisterDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userExist = await _userManager.FindByNameAsync(user.UserName);
            if(userExist != null)
            {
                return BadRequest("User already exists");
            }
            var basket = new Basket
            {
                Id= Guid.NewGuid()
            };
            var usertToCreate = new User
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ProfileImgSrc = user.ProfileImageSrc,
                Basket = basket,
                BasketId = basket.Id

            };
            var result = await _userManager.CreateAsync(usertToCreate, user.Password);
            var userToReturn =  _mapper.Map<UserDTO>(usertToCreate);
            if (!result.Succeeded)
            {
                return BadRequest("Failed to create user");
            }        
            return Ok(userToReturn);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO user)
        {
            var userExists = await _userManager.FindByEmailAsync(user.Email);
            if(userExists != null && await _userManager.CheckPasswordAsync(userExists, user.Password))
            {
               var claimsForToken = new List<Claim>
                {
                    new Claim("Id", userExists.Id.ToString()),
                    new Claim("UserName", userExists.UserName),
                    new Claim("Email", userExists.Email),
                    new Claim("ProfileImage", userExists.ProfileImgSrc),
                    new Claim("IsLoggedIn", true.ToString(), ClaimValueTypes.Boolean),
                };

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Token"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["Authentication:ValidIssuer"],
                    audience: _configuration["Authentication:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: claimsForToken,
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                 );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
        [HttpPost]
        [Route("asign-role")]
        public async Task<IActionResult> AsignRole(string userName, string roleName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return NotFound();
            }
            var role = await _roleManager.FindByNameAsync(roleName);
            if(role == null)
            {
                var roleAdded = await _roleManager.CreateAsync(new ()
                {
                    Name = roleName
                });
            }
            var addRole = await _userManager.AddToRoleAsync(user, roleName);
            if (!addRole.Succeeded)
            {
                return BadRequest("Failed to add role to the user");
            }
            return Ok($"User added to {roleName} role");
        }
        [HttpPost]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePassword)
        {
            var user = await _userManager.FindByNameAsync(changePassword.UserName);
            if(user == null)
            {
                return NotFound();
            }
            var changedPassword = await _userManager.ChangePasswordAsync(user, changePassword.oldPassword, changePassword.newPassword);
            if (changedPassword.Succeeded)
            {
                return BadRequest("Failed to change password");
            }
            return Ok("Password changed successfully!");
        }
        [HttpDelete]
        [Route("deleteuser/{userId}")]
        public async Task<ActionResult> DeleteUser(Guid userId)
        {
            if (!await _userRepository.GetIfUserExistsAsync(userId))
            {
                return NotFound("The user does not exist");
            }
            var user = await _userRepository.GetUserAsync(userId);
            if(user == null)
            {
                return NotFound();
            } 
             _userRepository.DeleteUser(user);
            await _userRepository.SaveAsync();
            return Ok("The user has been deleted");
        }
    }
}
