namespace CotacaoBolsa.Domain.Entities
{
    public class Cotacao : BaseEntity
    {
        public DateTime DataCotacao { get; set; }
        public string CodigoAtivo { get; set; }
        public decimal ValorFechamento { get; set; }
    }
}
