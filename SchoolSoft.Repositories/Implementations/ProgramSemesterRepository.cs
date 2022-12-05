using SchoolSoft.Data;
using SchoolSoft.Models;
using SchoolSoft.Repositories.Interfaces;


namespace SchoolSoft.Repositories.Implementations
{
    public class ProgramSemesterRepository : GenericRepository<ProgramSemester>, IProgramSemesterRepository
    {
        public ProgramSemesterRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
