using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using MVCProject.Models;

namespace MVCProject.Models
{
    public class StudentManagementContext:DbContext
    {
        public StudentManagementContext(DbContextOptions options) : base(options)
        { 

        }
        public DbSet<StudentManagement> StudentManages { get; set; }
        public DbSet<MVCProject.Models.Login> Login { get; set; } = default!;
    }
}
