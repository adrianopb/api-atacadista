using ApiAtacadista.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace ApiAtacadista.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class OrcamentosController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody]Pedido pedido)
        {
            //TODO: função de criar orcamento -> modelo : orcamento -> paramentro id pedido 
            
            //TODO: função de atualizar notificação -> modelo : notificação -> paramentro id orcamento 

            //TODO: chamar função de criar a notificação na API do lojista
            
            return Ok();
        }
    }
}