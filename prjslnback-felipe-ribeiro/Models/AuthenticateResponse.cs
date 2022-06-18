using prjslnback_felipe_ribeiro.Entities;

namespace prjslnback_felipe_ribeiro.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Nome = user.Nome;
            Sobrenome = user.Sobrenome;
            Username = user.Username;
            Token = token;
        }
    }
}
