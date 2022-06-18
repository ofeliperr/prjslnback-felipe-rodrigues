using prjslnback_felipe_ribeiro.Entities;
using prjslnback_felipe_ribeiro.Models;
using prjslnback_felipe_ribeiro.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace prjslnback_felipe_ribeiroTest
{
    public class SenhaServiceFake : ISenhaService
    {
       
        public bool VerificarSenha(ValidarSenhaRequest model)
        {
            var senha = model.Senha;

            if (senha == null || senha == "")
                return false;

            if (senha.Length < 15)
                return false;

            if (!senha.Any(c => char.IsUpper(c)))
                return false;

            if (!senha.Any(c => char.IsLower(c)))
                return false;

            if (!(senha.Contains("@") || senha.Contains("#") || senha.Contains("_") || senha.Contains("-") || senha.Contains("!")))
                return false;

            var repetido = 0;
            var ultimoCaracter = '\0';
            foreach (var c in senha)
            {
                if (c == ultimoCaracter)
                    repetido++;
                else
                    repetido = 0;
                if (repetido == 1)
                    return false;
                ultimoCaracter = c;
            }

            return true;
        }

        public string GeraSenhaAleatoria()
        {
            const string caixa_baixa = "abcdefghijklmnopqrstuvwxyz";
            const string caixa_alta = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string especiais = @"@#_-!";

            string permitido = "";
            permitido += caixa_baixa;
            permitido += caixa_alta;
            permitido += especiais;

            int numero_caracteres = 15;

            // Definições
            string _senha = "";
            if (_senha.IndexOfAny(caixa_baixa.ToCharArray()) == -1)
                _senha += RandomChar(caixa_baixa);
            if (_senha.IndexOfAny(caixa_alta.ToCharArray()) == -1)
                _senha += RandomChar(caixa_alta);
            if (_senha.IndexOfAny(especiais.ToCharArray()) == -1)
                _senha += RandomChar(especiais);
            // Aleatorios
            while (_senha.Length < numero_caracteres)
                _senha += RandomChar(permitido);
            // Random
            _senha = RandomizeString(_senha);
            return _senha;
        }

        public static char RandomChar(string text)
        {
            Random rand = new Random();
            int num = rand.Next(0, text.Length);
            return text[num];
        }

        private string RandomizeString(string str)
        {
            string resultado = "";
            Random rand = new Random();
            while (str.Length > 0)
            {
                int i = rand.Next(0, str.Length);
                resultado += str.Substring(i, 1);
                str = str.Remove(i, 1);
            }
            return resultado;
        }
    }
}
