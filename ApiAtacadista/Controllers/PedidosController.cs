using ApiAtacadista.Entidades;
using ApiAtacadista.Enum;
using ApiAtacadista.Negocios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAtacadista.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private PedidoNegocio _pedidoNegocio = new PedidoNegocio();
        private NotificacaoNegocio _notificacaoNegocio = new NotificacaoNegocio();

        /// <summary>
        /// Recebimento de pedido do lojista
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<Notificacao> Post([FromBody]Pedido pedido)
        {
            Pedido novoPedido = new Pedido();
            Notificacao novaNotificacao = new Notificacao();
            
            novoPedido = _pedidoNegocio.CriarPedido(pedido);
            novaNotificacao = _notificacaoNegocio.CriarNotificacao(novoPedido.Id);

            if (novaNotificacao == null || novoPedido == null)
            {
                return StatusCode(500);
            }   
            
            return Ok(novaNotificacao);
        }
        
        /// <summary>
        /// Lista todos os pedidos a partir dos filtros passados
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}/status")]
        public IActionResult Put(int id, [FromBody]int status)
        {
            if (_pedidoNegocio.BuscarPedido(id) == null)
            {
                return NotFound();
            }
            //Função de atualizar o status do pedido
            return Ok(_pedidoNegocio.AtualizarPedidoStatus(id, status));
        }
    }
}
