using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using SchoolSoft.Services.Interfaces;
using SchoolSoft.ViewModels;

namespace SchoolSoft.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly INotyfService _notifyService;

        public StudentController(IStudentService studentService, INotyfService notifyService)
        {
            _studentService = studentService;
            _notifyService = notifyService;
        }

        public async Task<IActionResult> Index()
        {
            var studentsVM = new List<StudentViewModel>();
            try
            {
                studentsVM = await _studentService.GetAllStudents();
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }
            return View(studentsVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel vm)
        {
            if (!ModelState.IsValid) { return View(vm); }
            try
            {
                await _studentService.CreateStudent(vm);
                _notifyService.Success("Student Created Successfully");
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
            var studentVM = new StudentViewModel();
            try
            {
                studentVM = await _studentService.GetStudent(id);
                if (studentVM.Id == 0)
                {
                    _notifyService.Error($"Student of ID: {id} not found");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }

            return View(studentVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentViewModel vm)
        {
            if (!ModelState.IsValid) { return View(vm); }
            try
            {
                await _studentService.UpdateStudent(vm);
                _notifyService.Success("Student Updated Successfully");
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
                await _studentService.DeleteStudent(id);
                _notifyService.Success("Student Deleted Successfully");
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }

            return RedirectToAction("index");
        }
    }
}
