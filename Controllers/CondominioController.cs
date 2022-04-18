using System.Collections.Generic;
using admCondominio.Models;
using Microsoft.AspNetCore.Mvc;

namespace admCondominio.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CondominioController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public List<Condominio> Get()
        {
            return new List<Condominio>();
        }
    }
}