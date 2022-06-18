using prjslnback_felipe_ribeiro.Entities;
using prjslnback_felipe_ribeiro.Models;
using prjslnback_felipe_ribeiro.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace prjslnback_felipe_ribeiroTest
{
    public class UserServiceFake : IUserService
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, Nome = "Felipe", Sobrenome = "Ribeiro", Username = "felipe.ribeiro@teste.com.br", Password = "Felipe@ribeiro7" }
        };

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            if (user == null) return null;

            var token = "";

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}
