using IikoPetProject.Application.DTOs;
using IikoPetProject.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IikoPetProject.Api.Controllers
{
    /// <summary>
    /// ���������� �������������� (�����������/�����).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>��������� ������� ��������������.</summary>
        public AuthController(IAuthService authService) => _authService = authService;

        /// <summary>����������� ������ ������������.</summary>
        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto.Username, dto.Email, dto.Password);
            return Ok(result);
        }

        /// <summary>����������� ������������ (��������� JWT).</summary>
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto.Email, dto.Password);
            return Ok(result);
        }
    }
}
