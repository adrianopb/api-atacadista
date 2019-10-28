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
//        private NotificacaoNegocio _notificacaoNegocio = new NotificacaoNegocio();
        private static readonly HttpClient client = new HttpClient();
        private readonly string _URLCriacaoOrcamento = "https://localhost:5000/v1/orcamento";
        
        [HttpPost("/pedido/{idPedido}")]
        public async Task<ActionResult<Orcamento>> Post([FromRoute]int idPedido, [FromBody]int preco)
        {
            //Função de criar orcamento
            Orcamento orcamento = _orcamentoNegocio.CriarOrcamento(idPedido, preco);

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
        public IActionResult Put([FromRoute]int id, [FromBody]OrcamentoStatus status)
        {
            //TODO: função de verificar status orcamento = pendente (genérico) -> modelo : orcamento -> paramentros id orcamento, string status

            //TODO: função de atualizar orcamento -> modelo : orcamento -> paramentro id orcamento
            _orcamentoNegocio.AtualizarOrcamentoStatus(id, status);
            
            //TODO: função de atualizar notificação -> modelo : notificação -> paramentro id orcamento, id pedido
            
            return Ok();
        }
    }
}