using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolSoft.Models;
using SchoolSoft.Repositories.Interfaces;
using SchoolSoft.Services.Interfaces;
using SchoolSoft.ViewModels;

namespace SchoolSoft.Services.Implementations
{
    public class ProgramService : IProgramService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProgramService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateProgram(ProgramViewModel vm)
        {
            //getting selected semesters id
            var selectedSemetersId = vm.Semesters?.Where(x => x.Selected).Select(x => x.Value).Select(int.Parse).ToList();

            var programModel = new ProgramViewModel().ConvertViewModel(vm);
            programModel.ProgramSemesters = new List<ProgramSemester>();

            foreach(var semesterId in selectedSemetersId)
            {
                //adding semester and program to programsemester table
                programModel.ProgramSemesters.Add(new ProgramSemester()
                {
                    Program = programModel,
                    SemesterId = semesterId
                });
            }

            await _unitOfWork.Program.Create(programModel);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProgram(int id)
        {
            await _unitOfWork.Program.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<ProgramViewModel>> GetAllPrograms()
        {
            var programsModel = await _unitOfWork.Program.GetAll();
            var programsVM = ConvertModelListToViewModelList(programsModel);
            return programsVM;
        }

        public async Task<ProgramViewModel> GetProgram(int id)
        {
            var programVM = new ProgramViewModel();//create null object

            var programModel = await _unitOfWork.Program.GetBy(x => x.Id == id);

            if (programModel != null)
            {
                programVM = new ProgramViewModel(programModel);

                var semesters = await _unitOfWork.Semester.GetAll();
                var selectedSemesters = await _unitOfWork.ProgramSemester.GetAllBy(x => x.ProgramId == programModel.Id);

                programVM.Semesters = new List<SelectListItem>();
                programVM.Semesters = semesters.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

                foreach (var item in programVM.Semesters)
                {
                    foreach (var selectedSemister in selectedSemesters)
                    {
                        if (item.Value == selectedSemister.SemesterId.ToString())
                        {
                            item.Selected = true;
                        }
                    }
                }
            }
            return programVM;
        }

        public async Task UpdateProgram(ProgramViewModel vm)
        {
            var existingProgram = await _unitOfWork.Program.GetBy(x => x.Id == vm.Id);
            existingProgram.Name = vm.Name;
            existingProgram.Description = vm.Description;
            existingProgram.FacultyId = vm.FacultyId;

            var semesters = await _unitOfWork.ProgramSemester.GetAllBy(x=>x.ProgramId==existingProgram.Id);

            foreach (var item in semesters)
            {
                await _unitOfWork.ProgramSemester.Delete(item.Id);
            }

            var selectedSemetersId = vm.Semesters?.Where(x => x.Selected).Select(x => x.Value).Select(int.Parse).ToList();

            existingProgram.ProgramSemesters = new List<ProgramSemester>();

            foreach (var semesterId in selectedSemetersId)
            {
                //adding semester and program to programsemester table
                existingProgram.ProgramSemesters.Add(new ProgramSemester()
                {
                    Program = existingProgram,
                    SemesterId = semesterId
                });
            }
            _unitOfWork.Program.Edit(existingProgram);
            await _unitOfWork.SaveAsync();
        }


        //user defined fuction
        private List<ProgramViewModel> ConvertModelListToViewModelList(List<Program> programsModel)
        {
            return programsModel.Select(x => new ProgramViewModel(x)).ToList();
        }
    }
}
