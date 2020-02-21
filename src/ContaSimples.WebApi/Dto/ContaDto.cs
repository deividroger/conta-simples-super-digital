using ContaSimples.WebApi.CustomValidator;
using System.ComponentModel.DataAnnotations;

namespace ContaSimples.WebApi.Dto
{
    public class ContaDto
    {
        [Required(ErrorMessage = "A agência é obrigatória")]
        [RequiredGreaterThanZero(ErrorMessage = "A agência é obrigatória")]
        public int Agencia { get; set; }

        [Required(ErrorMessage = "A conta é obrigatória")]
        [RequiredGreaterThanZero(ErrorMessage = "A conta é obrigatória")]
        public int Conta { get; set; }
    }
}
