using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using prtfapi.Data;

namespace prtfapi.Controllers
{
    [ApiController]
    [Route("prtf/sayhi/{name}")]
    public class DefaultController : ControllerBase
    {
        public IActionResult Get(string name)
        {
            
            return Ok($"Hello {name} !");
        }
    }
}
