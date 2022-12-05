using SchoolSoft.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoft.Services.Interfaces
{
    public interface ISemesterService
    {
        public Task CreateSemester(SemesterViewModel vm);
        public Task UpdateSemester(SemesterViewModel vm);
        public Task<List<SemesterViewModel>> GetAllSemester();
        public Task<SemesterViewModel> GetSemester(int id);
        public Task DeleteSemester(int id);
    }
}
