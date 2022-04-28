using Microsoft.AspNetCore.Mvc;

namespace hydrants.Controllers;

[ApiController]
[Route("[controller]")]
public class HydrantController : ControllerBase
{

	private readonly ILogger<HydrantController> _logger;

	public HydrantController(ILogger<HydrantController> logger)
	{
		_logger = logger;
	}

	[HttpGet]
	public async Task<ContentResult> GetHydrants()
	{

		var fetch = new HttpClient();
		var result = await fetch.GetStringAsync("https://www.gatineau.ca/upload/donneesouvertes/BORNE_FONTAINE.xml");

		return Content(result, "application/xml");
	}
}
