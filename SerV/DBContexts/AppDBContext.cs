using Microsoft.EntityFrameworkCore;
using SerV.Data;

namespace SerV.DBContexts;

public class AppDBContext : DbContext
{
    public DbSet<AccessCode> AccessCodes { get; set; }
    public DbSet<AccessCodeUsage> AccessCodeUsageLog { get; set; }
    public DbSet<CV> CVs { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Skills> Skills { get; set; }

    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
        
    }
}
