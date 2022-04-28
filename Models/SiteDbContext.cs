using Microsoft.EntityFrameworkCore;

namespace hydrants.Models;

public class SiteDbContext : DbContext
{

	public SiteDbContext(DbContextOptions<SiteDbContext> opt) : base(opt) { }

	public DbSet<FetchCache>? FetchRecords { get; set; }
}