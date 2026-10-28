using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCore_CodeFirst_AsynchronousRequest_AspNetCore.Models
{
    public class EmpContext:DbContext
    {
        public EmpContext(DbContextOptions s) : base(s) { }
        public DbSet<EmpModel> Employee { get; set; }
    }
}
