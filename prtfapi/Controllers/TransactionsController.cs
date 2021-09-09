using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prtf.Controllers
{
    [ApiController]
    [Route("prtf/transactions")]
    public class TransactionsController : ControllerBase
    {
        public IActionResult Get(string id)
        {
            return Ok($"Transaction {id} !");
        }
    }
}
