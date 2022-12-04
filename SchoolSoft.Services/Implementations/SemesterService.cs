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
    }
}
