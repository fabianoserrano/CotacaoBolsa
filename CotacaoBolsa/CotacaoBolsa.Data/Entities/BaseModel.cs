using System.ComponentModel.DataAnnotations;

namespace CotacaoBolsa.Data.Entities
{
    public abstract class BaseModel
    {
        public int Id { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataModificacao { get; set; }
    }
}
