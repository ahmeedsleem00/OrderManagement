using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Order_Management.Dto;
using Order_Management.Errors;
using OrderManagement.Core.Entities;
using OrderManagement.Services;

namespace Order_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService,UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager,
                            ITokenService tokenService)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _userService.RegisterUserAsync(registerDto);
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok(new {Message = "User registered successfully" });

        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
                return Unauthorized(new ApiResponse(statusCode: 401, message: "You are not Authorized please Register First"));

            var Result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: false);

            if (!Result.Succeeded)
                return Unauthorized(value: new ApiResponse(statusCode: 401, message: "Password Incorrect Please Try Again :("));

            return Ok(value: new UserDto()
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = await _tokenService.CreateTokenAsync(user, _userManager),
                Message = "You're Successfully Logging In :)"
            });

        }
        [HttpPut(template: "emailExists")]
        public async Task<ActionResult<bool>> CheckEmailExists(string email)
        {
            return await _userManager.FindByEmailAsync(email) is not null;
        }
    }
}
