using crudApi_blazor022.Models;
using Microsoft.EntityFrameworkCore;

namespace crudApi_blazor022.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<DoctorData> Doctors { get; set; }
    }
}
