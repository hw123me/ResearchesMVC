using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResearchesMVC.Areas.Identity.Data;
using ResearchesMVC.Models;

namespace ResearchesMVC.Areas.Identity.Data;

public class ApplictionDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplictionDbContext(DbContextOptions<ApplictionDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

       
    }
   
    public DbSet<State> States { get; set; }
    public DbSet<City> Cities { get; set; }
   
    public DbSet<Status> Status { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<StudyTool> StudyTools { get; set; }
    public DbSet<StudySample> StudySamples { get; set; }
    public DbSet<OrderTool> OrderTools { get; set; }
    public DbSet<OrderSample> OrderSamples { get; set; }

}
public class ApplicationUserEntityConfiguration :IEntityTypeConfiguration<ApplicationUser>
{
    
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FullName).HasMaxLength(500);
        
    }
}
