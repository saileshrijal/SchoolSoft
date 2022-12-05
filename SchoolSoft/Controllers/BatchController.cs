using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using SchoolSoft.Services.Implementations;
using SchoolSoft.Services.Interfaces;
using SchoolSoft.ViewModels;

namespace SchoolSoft.Controllers
{
    public class BatchController : Controller
    {
        private readonly IBatchService _batchService;
        private readonly INotyfService _notifyService;

        public BatchController(IBatchService batchService, INotyfService notifyService)
        {
            _batchService = batchService;
            _notifyService = notifyService;
        }

        public async Task<IActionResult> Index()
        {
            var batchesVm = new List<BatchViewModel>();
            try
            {
                batchesVm = await _batchService.GetAllBatches();
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }
            return View(batchesVm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BatchViewModel vm)
        {
            if (!ModelState.IsValid) { return View(vm); }
            try
            {
                await _batchService.CreateBatch(vm);
                _notifyService.Success("Batch Created Successfully");
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
            var batchVM = new BatchViewModel();
            try
            {
                batchVM = await _batchService.GetBatch(id);
                if (batchVM.Id == 0)
                {
                    _notifyService.Error($"Batch of ID: {id} not found");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }

            return View(batchVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BatchViewModel vm)
        {
            if (!ModelState.IsValid) { return View(vm); }
            try
            {
                await _batchService.UpdateBatch(vm);
                _notifyService.Success("Batch Updated Successfully");
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
                await _batchService.DeleteBatch(id);
                _notifyService.Success("Batch Deleted Successfully");
            }
            catch (Exception ex)
            {
                _notifyService.Error(ex.Message);
            }

            return RedirectToAction("index");
        }
    }
}
