using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolSoft.Services.Implementations;
using SchoolSoft.Services.Interfaces;
using SchoolSoft.ViewModels;

namespace SchoolSoft.Controllers
{
    public class ProgramController : Controller
    {
        private readonly IProgramService _programService;
        private readonly INotyfService _notifyService;
        private readonly IFacultyService _facultyService;
        private readonly ISemesterService _semesterService;

        public ProgramController(IProgramService programService, 
                                INotyfService notifyService, 
                                IFacultyService facultyService,
                                ISemesterService semesterService)
        {
            _programService = programService;
            _notifyService = notifyService;
            _facultyService = facultyService;
            _semesterService = semesterService;
        }

        public async Task<IActionResult> Index()
        {
            var programsVM = new List<ProgramViewModel>();
            try
            {
                programsVM = await _programService.GetAllPrograms();
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }
            return View(programsVM);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new ProgramViewModel();
            try
            {
                var facultiesVM = await _facultyService.GetAllFaculties();
                var semestersVM = await _semesterService.GetAllSemester();
                vm.Faculties = facultiesVM.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();
                vm.Semesters = semestersVM.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();
            }
            catch(Exception ex)
            {
                _notifyService.Error(ex.Message);
            }
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProgramViewModel vm)
        {
            if (!ModelState.IsValid) { return View(vm); }
            try
            {
                await _programService.CreateProgram(vm);
                _notifyService.Success("Program Created Successfully");
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
                return View(vm);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var programVM = new ProgramViewModel();
            try
            {
                programVM = await _programService.GetProgram(id);
                var facultiesVM = await _facultyService.GetAllFaculties();
                programVM.Faculties = facultiesVM.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();
                if (programVM.Id == 0)
                {
                    _notifyService.Error($"Program of ID: {id} not found");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }

            return View(programVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProgramViewModel vm)
        {
            if (!ModelState.IsValid) { return View(vm); }
            try
            {
                await _programService.UpdateProgram(vm);
                _notifyService.Success("Program Updated Successfully");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
                return View(vm);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _programService.DeleteProgram(id);
                _notifyService.Success("Program Deleted Successfully");
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
