using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using SchoolSoft.Services.Implementations;
using SchoolSoft.Services.Interfaces;
using SchoolSoft.ViewModels;

namespace SchoolSoft.Controllers
{
    public class SemesterController : Controller
    {
        private readonly ISemesterService _semesterService;
        private readonly IProgramService _programService;
        private readonly INotyfService _notifyService;
        public SemesterController(ISemesterService semesterService, IProgramService programService, INotyfService notifyService)
        {
            _semesterService = semesterService;
            _programService = programService;
            _notifyService = notifyService;
        }
        public async Task<IActionResult> Index()
        {
            var semesterVm = new List<SemesterViewModel>();
            try
            {
                semesterVm = await _semesterService.GetAllSemester();
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }
            return View(semesterVm);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SemesterViewModel vm)
        {
            if (!ModelState.IsValid) { return View(vm); }
            try {
                await _semesterService.CreateSemester(vm);
                _notifyService.Success("Semester Created Successfully");
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }
            return View(vm);    
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var semesterVM = new SemesterViewModel();
            try
            {
                semesterVM = await _semesterService.GetSemester(id);
                if (semesterVM.Id == 0)
                {
                    _notifyService.Error($"Semester of ID: {id} not found");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }

            return View(semesterVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SemesterViewModel vm)
        {
            if (!ModelState.IsValid) { return View(vm); }
            try
            {
                await _semesterService.UpdateSemester(vm);
                _notifyService.Success("Semester Updated Successfully");
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
                await _semesterService.DeleteSemester(id);
                _notifyService.Success("Semester Deleted Successfully");
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }

            return RedirectToAction("index");
        }
    }
}
