using SchoolSoft.Data;
using SchoolSoft.Models;
using SchoolSoft.Repositories.Interfaces;


namespace SchoolSoft.Repositories.Implementations
{
    public class SemesterRepository : GenericRepository<Semester>, ISemesterRepository
    {
        public SemesterRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
