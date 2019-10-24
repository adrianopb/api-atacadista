using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiAtacadista.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string status)
        {
            //TODO: 
        }
    }
}
