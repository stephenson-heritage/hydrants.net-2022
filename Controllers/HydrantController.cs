using hydrants.Models;
using Microsoft.AspNetCore.Mvc;

namespace hydrants.Controllers;

[ApiController]
[Route("[controller]")]
public class HydrantController : ControllerBase
{

	private readonly ILogger<HydrantController> _logger;
	private readonly SiteDbContext _context;


	public HydrantController(ILogger<HydrantController> logger, SiteDbContext context)
	{
		_logger = logger;
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult> GetHydrants()
	{

		string url = "https://www.gatineau.ca/upload/donneesouvertes/BORNE_FONTAINE.xml".ToLower();

		FetchCache? nFetch = null;

		if (_context.FetchRecords != null)
		{
			nFetch = _context.FetchRecords.Where(fr => fr.Url.ToLower() == url).OrderByDescending(fr => fr.Time).FirstOrDefault();
			if (nFetch != null)
			{
				if ((DateTime.Now - nFetch.Time).TotalHours < 4)
				{
					return Content(nFetch.Data, "application/xml");
				}
			}
		}


		var fetch = new HttpClient();
		try
		{
			var result = await fetch.GetStringAsync(url);
			if (_context.FetchRecords != null)
			{
				_context.FetchRecords.Add(new FetchCache { Data = result, Time = DateTime.Now, Url = url });
				await _context.SaveChangesAsync();
			}
			return Content(result, "application/xml");
		}
		catch (Exception)
		{
			if (nFetch != null)
			{
				_logger.Log(LogLevel.Warning, $"site unreachable, using cached data for {url}");
				return Content(nFetch.Data, "application/xml");
			}
		}

		return BadRequest();

	}
}
