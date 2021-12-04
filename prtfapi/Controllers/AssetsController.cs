using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using prtfapi.Portfolio;
using prtfapi.Data;
using System.Linq.Expressions;

namespace prtfapi.Controllers
{
	[ApiController]
	[Route("prtf/assets")]
	public class AssetsController : ControllerBase
	{
		private readonly IRepository<Asset> assets;
		
		public AssetsController()
		{
			assets = Program.dataContext.GetRepository<Asset>();
		}

		[HttpPost]
		public ActionResult CreateAsset([FromBody] Asset asset)
		{
			assets.Add(asset);
			return Created($"assets/{asset.ticker}", asset);
		}

		[HttpGet]
		public ActionResult GetAll([FromQuery] string[] tags, [FromQuery] string ticker, [FromQuery] string name)
		{
			return Ok(assets.All());
		}

		[HttpGet]
		[Route("{ticker}")]
		public ActionResult Get(string ticker)
		{
			Asset asset = assets.WhereOne(i => i.ticker.Equals(ticker));
			if (asset == null)
				return NotFound();
			return Ok(asset);
		}

		[HttpDelete]
		[Route("{ticker}")]
		public ActionResult Delete(string ticker)
		{
			assets.RemoveWhere(i => i.ticker.Equals(ticker));
			return Ok();
		}

		[HttpPatch]
		public ActionResult Update([FromBody] Asset asset)
		{
			assets.UpdateOne(a => a.ticker.Equals(asset.ticker), asset);
			return Ok();
		}
	}
}
