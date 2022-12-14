using Microsoft.EntityFrameworkCore;
using SchoolSoft.Models;
using SchoolSoft.Repositories.Interfaces;
using SchoolSoft.Services.Interfaces;
using SchoolSoft.ViewModels;

namespace SchoolSoft.Services.Implementations
{
    public class FacultyService : IFacultyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FacultyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateFaculty(FacultyViewModel vm)
        {
            var facultyModel = new FacultyViewModel().ConvertViewModel(vm);
            await _unitOfWork.Faculty.Create(facultyModel);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateFaculty(FacultyViewModel vm)
        {
            var facultyModel = new FacultyViewModel().ConvertViewModel(vm);
            var existingFaculty = await _unitOfWork.Faculty.GetBy(x=>x.Id==facultyModel.Id);
            existingFaculty.Name = vm.Name;
            existingFaculty.Description = vm.Description;
            await _unitOfWork.SaveAsync();
        }


        public async Task<List<FacultyViewModel>> GetAllFaculties()
        {
            var facultiesModel = await _unitOfWork.Faculty.GetAll();
            var facultiesVM = ConvertModelListToViewModelList(facultiesModel);
            return facultiesVM;
        }

        public async Task DeleteFaculty(int id)
        {
            await _unitOfWork.Faculty.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<FacultyViewModel> GetFaculty(int id)
        {
            var facultyVM = new FacultyViewModel();//create null object
            var facultyModel = await _unitOfWork.Faculty.GetBy(x => x.Id == id);
            if(facultyModel != null)
            {
                facultyVM = new FacultyViewModel(facultyModel);
            }
            return facultyVM;
        }


        //user defined fuction
        private List<FacultyViewModel> ConvertModelListToViewModelList(List<Faculty> facultiesModel)
        {
            return facultiesModel.Select(x => new FacultyViewModel(x)).ToList();
        }
    }
}
