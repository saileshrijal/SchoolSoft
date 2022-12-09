using SchoolSoft.Data;
using SchoolSoft.Repositories.Interfaces;

namespace SchoolSoft.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public IFacultyRepository Faculty { get; private set; }
        public IProgramRepository Program { get; private set; }
        public ISemesterRepository Semester { get; private set; }
        public IProgramSemesterRepository ProgramSemester { get; private set; }
        public IBatchRepository Batch { get; private set; }
        public IStudentRepository Student { get; private set; }
        public IParentRepository Parent { get; private set; }

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Faculty = new FacultyRepository(context);
            Program = new ProgramRepository(context);
            Semester = new SemesterRepository(context);
            ProgramSemester = new ProgramSemesterRepository(context);
            Batch = new BatchRepository(context);
            Student = new StudentRepository(context);
            Parent = new ParentRepository(context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

