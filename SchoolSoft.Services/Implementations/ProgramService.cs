using SchoolSoft.Models;
using SchoolSoft.Repositories.Interfaces;
using SchoolSoft.Services.Interfaces;
using SchoolSoft.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
            return programVM;
        }

        public async Task UpdateProgram(ProgramViewModel vm)
        {
            var programModel = new ProgramViewModel().ConvertViewModel(vm);
            var existingProgram = await _unitOfWork.Program.GetBy(x => x.Id == programModel.Id);
            existingProgram.Name = vm.Name;
            existingProgram.Description = vm.Description;
            existingProgram.FacultyId = vm.FacultyId;
            await _unitOfWork.SaveAsync();
        }


        //user defined fuction
        private List<ProgramViewModel> ConvertModelListToViewModelList(List<Program> programsModel)
        {
            return programsModel.Select(x => new ProgramViewModel(x)).ToList();
        }
    }
}
