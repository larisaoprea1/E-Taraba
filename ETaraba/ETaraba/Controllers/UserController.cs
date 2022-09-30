using AutoMapper;
using ETaraba.Application.IRepositories;
using ETaraba.Application.Users.Commands.DeleteUser;
using ETaraba.Application.Users.Commands.Login;
using ETaraba.Application.Users.Commands.Register;
using ETaraba.Application.Users.Querries.GetAllUsers;
using ETaraba.Application.Users.Querries.GetUserByEmail;
using ETaraba.Application.Users.Querries.GetUserById;
using ETaraba.Application.Users.Querries.GetUserByUsername;
using ETaraba.Domain.Models;
using ETaraba.DTOs.UserDTOs;
using ETaraba.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        private readonly IMediator _mediator;
        public UserController(UserManager<User> userManager,
            RoleManager<UserRole> roleManager,
            IMapper mapper,
            IUserRepository userRepository,
            IConfiguration configuration, IMediator mediator)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)) ;
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet("username")]
        public async Task<IActionResult> GetUserByUserName(string username)
        {
            var userToFind = await _mediator.Send(new GetUserByUsernameQuery
            {
                UserName = username
            });
            return Ok(_mapper.Map<UserDTO>(userToFind));
        }
        [HttpGet("email")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var userToFind = await _mediator.Send(new GetUserByEmailQuery
            {
                Email = email
            });
            return Ok(_mapper.Map<UserDTO>(userToFind));
        }
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var usersToGet = await _mediator.Send(new GetAllUsersQuery());
            return Ok(_mapper.Map<IEnumerable<UserDTO>>(usersToGet));
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid userId)
        {
            var userById = await _mediator.Send(new GetUserByIdQuery
            {
                Id = userId
            });
            return Ok(_mapper.Map<UserDTO>(userById));
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register( [FromBody] RegisterDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userUsername = await _mediator.Send(new GetUserByUsernameQuery
            {
                UserName = user.UserName
            });
            if (userUsername != null)
            {
                return BadRequest("400");
            }
            var userEmail = await _mediator.Send(new GetUserByEmailQuery
            {
                Email = user.Email
            });
            if (userEmail != null)
            {
                return BadRequest("400");
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
            var result = await _mediator.Send(new RegisterCommand
            {
                User = usertToCreate,
                Password = user.Password,
                
            });
            var userToReturn =  _mapper.Map<UserDTO>(result);
            if (result == null)
            {
                return BadRequest("400");
            }
            return Ok(userToReturn);
        }
        [HttpPost]
        [Route("login")]
        public async Task<object> Login([FromBody] LoginDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _mediator.Send(new LoginCommand
            {
                Email = user.Email,
                Password =user.Password
            });
            if(result == "401")
            {
                return Unauthorized("401");
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("assign-role")]
        public async Task<IActionResult> AssignRole(string userName, string roleName)
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
                return BadRequest("400");
            }
            return Ok($"200, {roleName} role");
        }
        [HttpPost]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePassword)
        {
            string claim = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByNameAsync(claim);
            var changedPassword = await _userManager.ChangePasswordAsync(user, changePassword.oldPassword, changePassword.newPassword);
            if (!changedPassword.Succeeded)
            {
                return BadRequest("400");
            }
            return Ok("200");
        }
        [HttpDelete]
        [Route("deleteuser/{userId}")]
        public async Task<ActionResult> DeleteUser([FromRoute] Guid userId)
        {
           await _mediator.Send(new DeleteUserCommand
            {
                Id = userId
            });
            return Ok("200");
        }
    }
}
