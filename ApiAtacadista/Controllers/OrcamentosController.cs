using System;
using System.Net.Http;
using System.Threading.Tasks;
using ApiAtacadista.Entidades;
using ApiAtacadista.Enum;
using ApiAtacadista.Negocios;
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
        
        [HttpPost("/v1/pedidos/{id}/orcamentos")]
        public async Task<ActionResult<Orcamento>> Post(int id, [FromBody]Preco preco)
        {
            if (_pedidoNegocio.BuscarPedido(id) == null)
            {
                return NotFound("Pedido não encontrado");
            }
            
            //Função de criar orcamento
            Orcamento orcamento = _orcamentoNegocio.CriarOrcamento(id, preco);

            //Função de criar o orçamento na API do lojista
            var respostaOrcamento = await client.PostAsJsonAsync(_URLCriacaoOrcamento, orcamento);
            var respostaOrcamentoString = await respostaOrcamento.Content.ReadAsStringAsync();

            if (!respostaOrcamento.IsSuccessStatusCode)
            {
                throw new Exception(respostaOrcamentoString);
            }
            
            return Ok(respostaOrcamento);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OrcamentoStatus status)
        {
            //Função de atualizar orcamento -> modelo : orcamento -> paramentro id orcamento
            _orcamentoNegocio.AtualizarOrcamentoStatus(id, status);
            
            return Ok();
        }
    }
}