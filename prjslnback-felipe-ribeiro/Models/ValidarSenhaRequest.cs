using System.ComponentModel.DataAnnotations;


namespace prjslnback_felipe_ribeiro.Models
{
    public class ValidarSenhaRequest
    {

        [Required]
        public string Senha { get; set; }
    }
}
