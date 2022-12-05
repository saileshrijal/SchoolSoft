using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolSoft.Models;
using SchoolSoft.Repositories.Interfaces;
using SchoolSoft.Services.Interfaces;
using SchoolSoft.ViewModels;

namespace SchoolSoft.Services.Implementations
{
    public class SemesterService: ISemesterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SemesterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;  
        }
        public async Task CreateSemester(SemesterViewModel vm)
        {
            var semesterModel = new SemesterViewModel().ConvertViewModel(vm);
            await _unitOfWork.Semester.Create(semesterModel);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateSemester(SemesterViewModel vm)
        {
            var semesterModel = new SemesterViewModel().ConvertViewModel(vm);
            var existingSemester = await _unitOfWork.Semester.GetBy(x => x.Id == semesterModel.Id);
            existingSemester.Name = vm.Name;
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<SemesterViewModel>> GetAllSemester()
        {
            var semesterModel = await _unitOfWork.Semester.GetAll();
            var semesterVm = ConvertModelListToViewModelList(semesterModel);
            return semesterVm;
        }

        private List<SemesterViewModel> ConvertModelListToViewModelList(List<Semester> semesterModel)
        {
            return semesterModel.Select(x => new SemesterViewModel(x)).ToList();
        }

        public async Task<SemesterViewModel> GetSemester(int id)
        {
            var semesterVM = new SemesterViewModel();//create null object
            var semesterModel = await _unitOfWork.Semester.GetBy(x => x.Id == id);
            if (semesterModel != null)
            {
                semesterVM = new SemesterViewModel(semesterModel);
            }
            return semesterVM;
        }

        public async Task DeleteSemester (int id)
        {
            await _unitOfWork.Semester.Delete(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
