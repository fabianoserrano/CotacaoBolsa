using System.ComponentModel;

namespace CotacaoBolsa.Application.ViewModels.Cotacao
{
    public class CotacaoViewModel : CotacaoUpdateViewModel
    {
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Data de Modificação")]
        public DateTime DataModificacao { get; set; }
    }
}
