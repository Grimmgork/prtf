using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace prtfapi.Controllers
{
    public class DefaultController : ControllerBase
    {
        [Route("sayhi/{name}")]
        public IActionResult Get(string name)
        {
            return Ok($"Hello {name} !");
        }
    }
}
