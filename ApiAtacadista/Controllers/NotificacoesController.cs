using ApiAtacadista.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace ApiAtacadista.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class NotificacoesController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody]Pedido pedido)
        {
            
            //TODO: função de criar notificação -> modelo : notificacao -> paramentro id pedido 

            //TODO: opcional -> verificar de produto existe (pelo CodigoProduto)

            return Ok();
        }
    }
}