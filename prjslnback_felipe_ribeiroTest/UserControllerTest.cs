using Microsoft.AspNetCore.Mvc;
using prjslnback_felipe_ribeiro.Controllers;
using prjslnback_felipe_ribeiro.Models;
using prjslnback_felipe_ribeiro.Services;
using Xunit;

namespace prjslnback_felipe_ribeiroTest
{
    public class UserControllerTest
    {
        UserController _controller;
        IUserService _service;
        ISenhaService _serviceSenha;
        public UserControllerTest()
        {
            _service = new UserServiceFake();
            _serviceSenha = new SenhaServiceFake();
            _controller = new UserController(_service, _serviceSenha);
        }

        // TESTE MÉTODO 1
        [Fact]
        public void Authenticate_OkResult()
        {
            var user = new AuthenticateRequest();
            user.Username = "felipe.ribeiro@teste.com.br";
            user.Password = "Felipe@ribeiro7";
            // Act
            var okResult = _controller.Authenticate(user);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Authenticate_BadResult()
        {
            var user = new AuthenticateRequest();
            user.Username = "felipe.ribeiro@teste.com.br";
            user.Password = "teste";

            // Act
            var badResult = _controller.Authenticate(user);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResult);
        }

        // TESTE MÉTODO 2
        [Fact]
        public void VerificarSenha_OkResult()
        {
            var obj = new ValidarSenhaRequest();
            obj.Senha = "FeEelipe_ribeiro1717";
       
            // Act
            var okResult = _controller.VerificarSenha(obj);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void VerificarSenha_BadResult()
        {
            var obj = new ValidarSenhaRequest();
            obj.Senha = "FeEeliperibeiro1717";

            // Act
            var badResult = _controller.VerificarSenha(obj);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResult);
        }

        // TESTE MÉTODO 3
        [Fact]
        public void GerarSenha_OkResult()
        {
            var actionResult = _controller.GerarSenha();
            var okResult = actionResult as OkObjectResult;
            var actualConfiguration = okResult.Value;

            var obj = new ValidarSenhaRequest();
            obj.Senha = actualConfiguration.ToString();

            // Act
            var okResultValid = _controller.VerificarSenha(obj);

            // Assert
            Assert.IsType<OkObjectResult>(okResultValid);
        }

        [Fact]
        public void Get_All_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
