using Microsoft.EntityFrameworkCore;

namespace DoctorOffice.Models
{
  public class DoctorOfficeContext : DbContext
  {
    public DbSet<Doc> Docs { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<DocPatient> DocPatient { get; set; }
    public DoctorOfficeContext(DbContextOptions options) :base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}