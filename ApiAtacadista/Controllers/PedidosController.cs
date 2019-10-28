using ApiAtacadista.Entidades;
using ApiAtacadista.Enum;
using ApiAtacadista.Negocios;
using Microsoft.AspNetCore.Mvc;

namespace ApiAtacadista.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private PedidoNegocio _pedidoNegocio = new PedidoNegocio();
        private NotificacaoNegocio _notificacaoNegocio = new NotificacaoNegocio();

        [HttpPost]
        public ActionResult<Notificacao> Post([FromBody]Pedido pedido)
        {
            Pedido novoPedido = new Pedido();
            Notificacao novaNotificacao = new Notificacao();
            
            novoPedido = _pedidoNegocio.CriarPedido(pedido);
            novaNotificacao = _notificacaoNegocio.CriarNotificacao(novoPedido.Id);
            
            return Ok(novaNotificacao);
        }
        
        [HttpPut("{id}/status")]
        public IActionResult Put([FromRoute]int id, [FromBody]PedidoStatus status)
        {
            //TODO: função de atualizar o status do pedido
            return Ok(_pedidoNegocio.AtualizarPedidoStatus(id, status));
        }
    }
}
