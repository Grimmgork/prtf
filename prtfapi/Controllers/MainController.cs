using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace prtfapi.Controllers
{
	[ApiController]
	[Route("prtf")]
	public class MainController : ControllerBase
	{
		[HttpGet]
		public ActionResult Logo()
		{
			return Ok(Program.logo);
		}
		
		[HttpGet]
		[Route("teapod")]
		public ActionResult ImATeapod()
		{
			return StatusCode(418);
		}
	}
}
