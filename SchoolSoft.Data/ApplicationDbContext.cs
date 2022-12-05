using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolSoft.Models;

namespace SchoolSoft.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Faculty>? Faculties { get; set; }
        public DbSet<Program>? Programs { get; set; }
        public DbSet<Semester>? Semesters { get; set; }
        public DbSet<ProgramSemester>? ProgramSemesters { get; set; }
        public DbSet<Batch>? Batches { get; set; }
    }
}
