using System.ComponentModel.DataAnnotations;

namespace ContaSimples.WebApi.Dto
{
    public class Usuario
    {
        [Required(ErrorMessage = "O documento é obrigatório")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]

        public string Email { get; set; }
    }
}
