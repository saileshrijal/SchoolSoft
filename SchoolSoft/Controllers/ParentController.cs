using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using SchoolSoft.Services.Interfaces;
using SchoolSoft.ViewModels;

namespace SchoolSoft.Controllers
{
    public class ParentController : Controller
    {
        private readonly IParentService _parentService;
        private readonly INotyfService _notifyService;

        public ParentController(IParentService parentService, INotyfService notifyService)
        {
            _parentService = parentService;
            _notifyService = notifyService;
        }

        public async Task<IActionResult> Index()
        {
            var parentsVm = new List<ParentViewModel>();
            try
            {
                parentsVm = await _parentService.GetAllParents();
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }
            return View(parentsVm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ParentViewModel vm)
        {
            if (!ModelState.IsValid) { return View(vm); }
            try
            {
                await _parentService.CreateParent(vm);
                _notifyService.Success("Parent Created Successfully");
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
            var parentVM = new ParentViewModel();
            try
            {
                parentVM = await _parentService.GetParent(id);
                if (parentVM.Id == 0)
                {
                    _notifyService.Error($"Parent of ID: {id} not found");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }

            return View(parentVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ParentViewModel vm)
        {
            if (!ModelState.IsValid) { return View(vm); }
            try
            {
                await _parentService.UpdateParent(vm);
                _notifyService.Success("Parent Updated Successfully");
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
                await _parentService.DeleteParent(id);
                _notifyService.Success("Parent Deleted Successfully");
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }

            return RedirectToAction("index");
        }
    }
}
