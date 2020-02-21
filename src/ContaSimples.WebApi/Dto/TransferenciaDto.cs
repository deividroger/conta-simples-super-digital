using ContaSimples.WebApi.CustomValidator;
using System.ComponentModel.DataAnnotations;

namespace ContaSimples.WebApi.Dto
{
    public class TransferenciaDto
    {
        [Required(ErrorMessage ="A conta de origem é obrigatória")]
        public ContaDto Origem { get; set; }

        [Required(ErrorMessage = "A conta de destino é obrigatória")]
        public ContaDto Destino { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório")]
        [RequiredGreaterThanZero(ErrorMessage = "O valor da transferência tem que ser maior que zero")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório")]
        public string AccessToken { get; set; }

    }
}