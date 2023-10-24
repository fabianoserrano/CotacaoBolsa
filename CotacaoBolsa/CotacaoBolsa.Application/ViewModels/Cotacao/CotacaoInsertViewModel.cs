using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CotacaoBolsa.Application.ViewModels.Cotacao
{
    public class CotacaoInsertViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Campo {0} obrigatório.")]
        [DisplayName("Data da Cotação")]
        public DateTime DataCotacao { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório.")]
        [MaxLength(6, ErrorMessage = "Máximo {1} caracteres para o campo {0}")]
        [MinLength(5, ErrorMessage = "Mínimo {1} caracteres para o campo {0}")]
        [DisplayName("Código do Ativo")]
        public string CodigoAtivo { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Valor não permitido para o campo {0}.")]
        [DisplayName("Valor de Fechamento")]
        public decimal ValorFechamento { get; set; }
    }
}
