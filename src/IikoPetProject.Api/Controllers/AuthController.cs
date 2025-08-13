using IikoPetProject.Application.DTOs;
using IikoPetProject.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IikoPetProject.Api.Controllers
{
    /// <summary>
    /// Контроллер аутентификации (регистрация/логин).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>Внедрение сервиса аутентификации.</summary>
        public AuthController(IAuthService authService) => _authService = authService;

        /// <summary>Регистрация нового пользователя.</summary>
        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto.Username, dto.Email, dto.Password);
            return Ok(result);
        }

        /// <summary>Авторизация пользователя (получение JWT).</summary>
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto.Email, dto.Password);
            return Ok(result);
        }
    }
}
