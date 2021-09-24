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
		public ActionResult<Asset> CreateAsset([FromBody] Asset asset)
		{
			DataSentinel.InsertAsset(asset);
			return Created($"assets/{asset.ticker}", asset);
		}

		[HttpGet]
		public ActionResult<Asset[]> GetAssets()
		{
			return Ok(DataSentinel.GetAssets());
		}

		[HttpGet]
		[Route("{ticker}")]
		public ActionResult<Asset> GetAsset(string ticker)
		{
			Asset asset = DataSentinel.GetAsset(ticker);
			if (asset == null)
				return BadRequest("Asset not found!");
			return Ok(asset);
		}

		[HttpDelete]
		[Route("{ticker}")]
		public ActionResult<string> DeleteAsset(string ticker)
		{
			DataSentinel.DeleteAsset(ticker);
			return Ok();
		}
	}
}
