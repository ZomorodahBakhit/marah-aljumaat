using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using University.Api.Filters;
using University.API.Helper;
using University.Core.Forms;
using University.Core.Services;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ApiExceptionFilter))]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenHelper _jwtTokenService;
        private readonly IAuthService _authService;

        public AuthController(IJwtTokenHelper jwtTokenHelper, IAuthService authService)
        {
            _jwtTokenService = jwtTokenHelper;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ApiResponse> Register([FromBody] RegisterForm form)
        {
            var dto = await _authService.Register(form);
            return new ApiResponse("User registered successfully", dto);
        }

        [HttpPost("login")]
        public async Task<ApiResponse> Login([FromBody] LoginForm form)
        {
            var user = await _authService.Login(form);
            var token = _jwtTokenService.GenerateToken(user);
            return new ApiResponse("Login successful", token);
        }
    }
}
