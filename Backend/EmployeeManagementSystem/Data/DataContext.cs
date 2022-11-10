using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EmployeeDesignationDetail> EmployeeDesignationDetails { get; set; }    
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<PaymentRule> PaymentRules { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }
    }
}
