using SchoolSoft.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoft.Services.Interfaces
{
    public interface IProgramService
    {
        Task<List<ProgramViewModel>> GetAllPrograms();
        Task<ProgramViewModel> GetProgram(int id);
        public Task UpdateProgram(ProgramViewModel vm);
        public Task DeleteProgram(int id);
        Task CreateProgram(ProgramViewModel vm);
    }
}
