using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    [Route("healthz")]
    public class HealthController : ControllerBase
    {

        ///<summary>
        ///Este controlador es para verificar el estado de la aplicación
        ///</summary>
        [HttpGet]
        public IActionResult CheckHealthEndpoint()
        {
            return Ok();
        }
    }
}