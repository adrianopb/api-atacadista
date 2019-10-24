using ApiAtacadista.Entidades;
using ApiAtacadista.Negocios;
using Microsoft.AspNetCore.Mvc;

namespace ApiAtacadista.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class OrcamentosController : Controller
    {
        private OrcamentoNegocio _orcamentoNegocio = new OrcamentoNegocio();
        private NotificacaoNegocio _notificacaoNegocio = new NotificacaoNegocio();
        
        [HttpPost("/pedido/{idPedido}/orcamento")]
        public IActionResult Post([FromRoute]int idPedido, [FromBody]int preco)
        {
            //Função de criar orcamento
            Orcamento orcamento = _orcamentoNegocio.CriarOrcamento(idPedido, preco);
            
            //TODO: chamar função de verificar se notificação existe
            
            //Função de atualizar notificação -> modelo : notificação -> paramentro id orcamento
            Notificacao notificacao = _notificacaoNegocio.AtualizarNotificacaoOrcamento(idPedido, orcamento.Id);

            //TODO: chamar função de criar a notificação na API do lojista
            
            return Ok();
        }
        
        [HttpPost]
        public IActionResult Put([FromBody]Pedido pedido, string status)
        {
            //TODO: função de verificar status orcamento = pendente (genérico) -> modelo : orcamento -> paramentros id orcamento, string status
            
            //TODO: função de atualizar orcamento -> modelo : orcamento -> paramentro id orcamento   (aceito)
            
            //TODO: função de atualizar notificação -> modelo : notificação -> paramentro id orcamento, id pedido
            
            return Ok();
        }
    }
}