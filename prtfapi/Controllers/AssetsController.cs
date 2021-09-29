using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using prtfapi.Portfolio;
using prtfapi.Data;

namespace prtfapi.Controllers
{
	[ApiController]
	[Route("prtf/assets")]
	public class AssetsController : ControllerBase
	{
		[HttpPost]
		public ActionResult CreateAsset([FromBody] Asset asset)
		{
			DataSentinel.InsertAsset(asset);
			return Created($"assets/{asset.ticker}", asset);
		}

		[HttpGet]
		public ActionResult GetAll()
		{
			return Ok(DataSentinel.GetAssets());
		}

		[HttpGet]
		[Route("{ticker}")]
		public ActionResult Get(string ticker)
		{
			Asset asset = DataSentinel.GetAsset(ticker);
			if (asset == null)
				return NotFound();
			return Ok(asset);
		}

		[HttpDelete]
		[Route("{ticker}")]
		public ActionResult Delete(string ticker)
		{
			DataSentinel.DeleteAsset(ticker);
			return Ok();
		}

		[HttpPut]
		[Route("{ticker}")]
		public ActionResult Replace(string ticker, [FromBody] Asset asset)
		{
			if (DataSentinel.GetAsset(ticker) == null)
				return NotFound();

			DataSentinel.InsertAsset(asset);
			return Ok();
		}
	}
}
