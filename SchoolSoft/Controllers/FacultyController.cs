using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSoft.Services.Interfaces;
using SchoolSoft.ViewModels;

namespace SchoolSoft.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IFacultyService _facultyService;
        private readonly INotyfService _notifyService;

        public FacultyController(IFacultyService facultyService, INotyfService notifyService)
        {
            _facultyService = facultyService;
            _notifyService = notifyService;
        }

        public async Task<IActionResult> Index()
        {
            var facultiesVM = new List<FacultyViewModel>();
            try
            {
                facultiesVM = await _facultyService.GetAllFaculties();
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }
            return View(facultiesVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FacultyViewModel vm)
        {
            if (!ModelState.IsValid) { return View(vm); }
            try
            {
                await _facultyService.CreateFaculty(vm);
                _notifyService.Success("Faculty Created Successfully");
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
            var facultyVM = new FacultyViewModel();
            try
            {
                facultyVM = await _facultyService.GetFaculty(id);
                if (facultyVM.Id == 0)
                {
                    _notifyService.Error($"Faculty of ID: {id} not found");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception ex)
            {
                _notifyService.Error(ex.Message);
            }
            
            return View(facultyVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FacultyViewModel vm)
        {
            if (!ModelState.IsValid) { return View(vm); }
            try
            {
                await _facultyService.UpdateFaculty(vm);
                _notifyService.Success("Faculty Updated Successfully");
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
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
                await _facultyService.DeleteFaculty(id);
                _notifyService.Success("Faculty Deleted Successfully");
            }
            catch(Exception ex)
            {
                _notifyService.Error(ex.Message);
            }
            
            return RedirectToAction("index");
        }

    }
}
