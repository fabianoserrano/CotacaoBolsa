using Microsoft.AspNetCore.Mvc;
using CotacaoBolsa.Application.ViewModels.Cotacao;
using CotacaoBolsa.Application.Interfaces;

namespace CotacaoBolsa.API.Controllers
{
    public class CotacaoController : ControllerBase
    {
        public readonly ICotacaoAppService _appService;

        public CotacaoController(ICotacaoAppService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// Inclui uma Cotação
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     PUT /incluirCotacao
        ///     {
        ///         "dataCotacao": "2023-07-31T00:00:00",
        ///         "codigoAtivo": "BBSE3",
        ///         "valorFechamento": 1.23  
        ///     }
        ///     
        /// </remarks>
        /// <param name="cotacao">Data, Código do Ativo e Valor de fechamento da Cotação</param>
        /// <returns>A nova Cotação</returns>
        /// <response code="200">Cotação criada</response>
        [HttpPut("incluirCotacao")]
        public IActionResult Insert([FromBody] CotacaoInsertViewModel cotacao)
        {
            //2023-10-19
            //BBSE3
            //1.23
            try
            {
                var cotacaoIncluida = _appService.Insert(cotacao);
                return Ok(cotacaoIncluida);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Altera uma Cotação
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     POST /alterarCotacao
        ///     {
        ///         "id": 1,
        ///         "dataCotacao": "2023-07-31T00:00:00",
        ///         "codigoAtivo": "BBSE3",
        ///         "valorFechamento": 4.56
        ///     }
        ///     
        /// </remarks>
        /// <param name="cotacao">Identificador, Data, Código do Ativo e Valor de fechamento da Cotação</param>
        /// <returns>A Cotação alterada</returns>
        /// <response code="200">Cotação alterada</response>
        /// <response code="404">Cotação não encontrada</response>
        [HttpPost("alterarCotacao")]
        public IActionResult Update([FromBody] CotacaoUpdateViewModel cotacao)
        {
            try
            {
                if (_appService.Get(cotacao.Id, true) == null)
                    return NotFound();

                var cotacaoAlterada = _appService.Update(cotacao);
                return Ok(cotacaoAlterada);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Exclui uma Cotação
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     DELETE /excluirCotacao/1
        ///     
        /// </remarks>
        /// <param name="id">Um número inteiro com o valor do identificador da Cotação</param>
        /// <returns></returns>
        /// <response code="200">Cotação excluída</response>
        /// <response code="404">Cotação não encontrada</response>
        [HttpDelete("excluirCotacao/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_appService.Get(id, true) == null)
                    return NotFound();

                _appService.Delete(id);
                return Ok();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lista todas as Cotações
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     GET /obterCotacoes
        ///     
        /// </remarks>
        /// <returns>As Cotações</returns>
        /// <response code="200">Cotações</response>
        [HttpGet("obterCotacoes")]
        public IActionResult Get()
        {
            try
            {
                var cotacoes = _appService.Get(true);
                return Ok(cotacoes);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lista uma Cotação específica dado o seu Id
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     GET /obterCotacaoPorId/1
        ///     
        /// </remarks>
        /// <param name="id">Um número inteiro com o valor do identificador da Cotação</param>
        /// <returns>A Cotação</returns>
        /// <response code="200">Cotação</response>
        /// <response code="404">Cotação não encontrada</response>
        [HttpGet("obterCotacaoPorId/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var cotacao = _appService.Get(id, true);
                return cotacao != null ? Ok(cotacao) : NotFound();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lista Cotações para uma data específica
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     GET /obterCotacoesPorData/2023-07-31
        ///     
        /// </remarks>
        /// <param name="dataCotacao">Uma data válida</param>
        /// <returns>As Cotações</returns>
        /// <response code="200">Cotações</response>
        /// <response code="404">Cotação não encontrada</response>
        [HttpGet("obterCotacoesPorData/{dataCotacao}")]
        public IActionResult Get(DateTime dataCotacao)
        {
            try
            {
                var cotacoes = _appService.Get(dataCotacao, true);
                return cotacoes != null ? Ok(cotacoes) : NotFound();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lista Cotações para um Ativo específico
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     GET /obterCotacoesPorAtivo/BBSE3
        ///     
        /// </remarks>
        /// <param name="codigoAtivo">Um código alfanumérico identificando o Ativo da Cotação</param>
        /// <returns>As Cotações</returns>
        /// <response code="200">Cotações</response>
        /// <response code="404">Cotação não encontrada</response>
        [HttpGet("obterCotacoesPorAtivo/{codigoAtivo}")]
        public IActionResult Get(string codigoAtivo)
        {
            try
            {
                var cotacoes = _appService.Get(codigoAtivo, true);
                return cotacoes != null ? Ok(cotacoes) : NotFound();
            }
            catch
            {
                throw;
            }
        }

        //mark here: publicação github (gitignore, etc.)
    }
}
