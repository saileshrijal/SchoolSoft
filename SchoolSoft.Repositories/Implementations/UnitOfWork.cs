using SchoolSoft.Data;
using SchoolSoft.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoft.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public IFacultyRepository Faculty { get; private set; }
        public IProgramRepository Program { get; private set; }
        public ISemesterRepository Semester { get; private set; }
        public IProgramSemesterRepository ProgramSemester { get; private set; }
        public IBatchRepository Batch { get; private set; }
    
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Faculty = new FacultyRepository(context);
            Program = new ProgramRepository(context);
            Semester = new SemesterRepository(context);
            ProgramSemester = new ProgramSemesterRepository(context);
            Batch = new BatchRepository(context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

