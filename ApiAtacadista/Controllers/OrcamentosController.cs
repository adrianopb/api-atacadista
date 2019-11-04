using System;
using System.Net.Http;
using System.Threading.Tasks;
using ApiAtacadista.Entidades;
using ApiAtacadista.Negocios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAtacadista.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class OrcamentosController : Controller
    {
        private OrcamentoNegocio _orcamentoNegocio = new OrcamentoNegocio();
        private PedidoNegocio _pedidoNegocio = new PedidoNegocio();
        
        private static readonly HttpClient client = new HttpClient();
        
        private readonly string _URLCriacaoOrcamento = "https://localhost:5000/v1/orcamento";

        /// <summary>
        /// Criação de proposta de orçamento para um pedido
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("/v1/orcamentos/pedidos/{id}")]
        public async Task<ActionResult<Orcamento>> Post(int id, [FromBody]Preco preco)
        {
            if (_pedidoNegocio.BuscarPedido(id) == null)
            {
                return NotFound("Pedido não encontrado");
            }
            
            //Função de criar orcamento
            Orcamento orcamento = _orcamentoNegocio.CriarOrcamento(id, preco);

            if (orcamento == null)
            {
                return StatusCode(500);
            }

            //Função de criar o orçamento na API do lojista
            var respostaOrcamento = await client.PostAsJsonAsync(_URLCriacaoOrcamento, orcamento);
            var respostaOrcamentoString = await respostaOrcamento.Content.ReadAsStringAsync();

            if (!respostaOrcamento.IsSuccessStatusCode)
            {
                throw new Exception(respostaOrcamentoString);
            }
            
            return Ok(respostaOrcamento);
        }
        
        /// <summary>
        /// Atualização de status de orçamento (aceito ou rejeitado)
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]int status)
        {
            if (_orcamentoNegocio.BuscarOrcamento(id) == null)
            {
                return NotFound();
            }
            
            //Função de atualizar orcamento -> modelo : orcamento -> paramentro id orcamento
            _orcamentoNegocio.AtualizarOrcamentoStatus(id, status);
            
            return Ok();
        }
    }
}