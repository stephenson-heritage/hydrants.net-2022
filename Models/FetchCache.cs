namespace hydrants.Models;

public class FetchCache
{

	public uint FetchCacheId { get; set; }
	public DateTime Time { get; set; } = DateTime.Now;
	public string Data { get; set; } = "";
	public string Url { get; set; } = "";
}