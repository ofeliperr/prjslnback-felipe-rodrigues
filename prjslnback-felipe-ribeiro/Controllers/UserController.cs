using Microsoft.AspNetCore.Mvc;
using prjslnback_felipe_ribeiro.Models;
using prjslnback_felipe_ribeiro.Services;

namespace prjslnback_felipe_ribeiro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private ISenhaService _senhaService;
        public UserController(IUserService userService, ISenhaService senhaService)
        {
            _userService = userService;
            _senhaService = senhaService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Usuário ou senha estão incorretos" });

            return Ok(response);
        }

        [Authorize]
        [HttpPost("verificar-senha")]
        public IActionResult VerificarSenha(ValidarSenhaRequest model)
        {
            var response = _senhaService.VerificarSenha(model);

            if (response)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [Authorize]
        [HttpGet("gerar-senha")]
        public IActionResult GerarSenha()
        {
            var response = _senhaService.GeraSenhaAleatoria();

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
