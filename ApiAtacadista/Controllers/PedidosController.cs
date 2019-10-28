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
        
        [HttpPut("{id}/status")]
        public ActionResult Put([FromRoute]int id, [FromBody]PedidoStatus status)
        {
            //TODO: função de atualizar o status do pedido
            return Ok(_pedidoNegocio.AtualizarPedidoStatus(id, status));
        }
    }
}
