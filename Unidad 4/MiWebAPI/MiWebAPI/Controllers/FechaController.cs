using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MiWebAPI.Models;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace MiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FechaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(new Fecha());
        }
    }
}
