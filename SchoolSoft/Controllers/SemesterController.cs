using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    }
}
