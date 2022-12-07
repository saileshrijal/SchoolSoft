using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoft.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IFacultyRepository Faculty { get; }
        IProgramRepository Program { get; }
        ISemesterRepository Semester { get; }
        IProgramSemesterRepository ProgramSemester { get; }
        IBatchRepository Batch { get; }
        IStudentRepository Student { get; }
        Task SaveAsync();
    }
}
