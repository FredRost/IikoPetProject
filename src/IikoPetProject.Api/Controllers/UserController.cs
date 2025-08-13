using IikoPetProject.Application.Interfaces;
using IikoPetProject.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IikoPetProject.Api.Controllers
{
    /// <summary>
    /// Контроллер чтения пользователей.
    /// Создание пользователей выполняется через <see cref="AuthController.Register(RegisterDto)"/>.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        /// <summary>Внедрение репозитория пользователей.</summary>
        public UserController(IUserRepository userRepository) => _userRepository = userRepository;

        /// <summary>Получить всех пользователей (требуется Bearer токен).</summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        /// <summary>Получить пользователя по Id (требуется Bearer токен).</summary>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<User>> GetById(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
