using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSoft.Services.Interfaces;
using SchoolSoft.ViewModels;

namespace SchoolSoft.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        public async Task<IActionResult> Index()
        {
            var listOfFacultiesVM = await _facultyService.GetAllFaculties();
            return View(listOfFacultiesVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FacultyViewModel model)
        {
            await _facultyService.CreateFaculty(model);
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var facultyVM = await _facultyService.GetFaculty(id);
            return View(facultyVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FacultyViewModel vm)
        {
            await _facultyService.UpdateFaculty(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _facultyService.DeleteFaculty(id);
            return RedirectToAction("index");
        }

    }
}
