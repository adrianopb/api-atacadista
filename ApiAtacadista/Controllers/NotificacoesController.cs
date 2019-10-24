using ApiAtacadista.Entidades;
using ApiAtacadista.Negocios;
using Microsoft.AspNetCore.Mvc;

namespace ApiAtacadista.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class NotificacoesController : Controller
    {
        private NotificacaoNegocio _notificacaoNegocio = new NotificacaoNegocio();
        
        [HttpPost]
        public IActionResult Post([FromBody]Pedido pedido)
        {
            //Função de criar notificação
            Notificacao notificacao = _notificacaoNegocio.CriarNotificacao(pedido.Id);

            //TODO: opcional -> verificar de produto existe (pelo CodigoProduto)

            return Ok();
        }
    }
}