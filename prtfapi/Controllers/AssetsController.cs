using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using prtfapi.Portfolio;

namespace prtfapi.Controllers
{
	[ApiController]
	[Route("prtf/assets")]
	public class AssetsController : ControllerBase
	{
		[HttpGet]
		public ActionResult<IEnumerable<string>> GetAssets()
		{
			return Ok();
		}

		[HttpGet("{ticker}")]
		public ActionResult<IEnumerable<string>> GetAsset(string ticker)
		{
			return Ok(new Asset() { ticker = "BTC", name="Bitcoin", description="A cryptocurrency!"});
		}
	}
}
