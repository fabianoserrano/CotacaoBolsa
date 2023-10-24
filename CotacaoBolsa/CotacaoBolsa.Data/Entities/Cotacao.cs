using System.ComponentModel.DataAnnotations;

namespace CotacaoBolsa.Data.Entities
{
    public class Cotacao : BaseModel
    {
        [Required]
        public DateTime DataCotacao { get; set; }
        [Required]
        [StringLength(6)]
        public string CodigoAtivo { get; set; }
        [Required]
        public decimal ValorFechamento { get; set; }
    }
}
