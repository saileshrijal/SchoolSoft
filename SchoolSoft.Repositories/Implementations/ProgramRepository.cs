using Microsoft.EntityFrameworkCore;
using SchoolSoft.Data;
using SchoolSoft.Models;
using SchoolSoft.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoft.Repositories.Implementations
{
    public class ProgramRepository : GenericRepository<Program>, IProgramRepository
    {
        public ProgramRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Program>> GetAll()
        {
            return await _context.Programs.Include(x=>x.Faculty).Include(x=>x.ProgramSemesters).ThenInclude(x=>x.Semester).ToListAsync();
        }
    }
}
