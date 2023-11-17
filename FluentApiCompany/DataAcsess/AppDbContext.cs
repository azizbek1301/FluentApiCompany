using FluentApiCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentApiCompany.DataAcsess
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
            
        

    }
}
