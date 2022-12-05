using SchoolSoft.Repositories.Interfaces;
using SchoolSoft.Services.Interfaces;
using SchoolSoft.ViewModels;
using SchoolSoft.Models;

namespace SchoolSoft.Services.Implementations
{
    public class BatchService : IBatchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BatchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateBatch(BatchViewModel vm)
        {
            var batchModel = new BatchViewModel().ConvertViewModel(vm);
            await _unitOfWork.Batch.Create(batchModel);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateBatch(BatchViewModel vm)
        {
            var batchModel = new BatchViewModel().ConvertViewModel(vm);
            var existingBatch = await _unitOfWork.Batch.GetBy(x => x.Id == batchModel.Id);
            existingBatch.Name = vm.Name;
            existingBatch.StartDate = vm.StartDate;
            existingBatch.EndDate = vm.EndDate;
            await _unitOfWork.SaveAsync();
        }
        public async Task<List<BatchViewModel>> GetAllBatches()
        {
            var BatchModel = await _unitOfWork.Batch.GetAll();
            var BatchesVM = ConvertModelListToViewModelList(BatchModel);
            return BatchesVM;
        }
        public async Task<BatchViewModel> GetBatch(int id)
        {
            var batchVm = new BatchViewModel();//create null object
            var batchModel = await _unitOfWork.Batch.GetBy(x => x.Id == id);
            if (batchModel != null)
            {
                batchVm = new BatchViewModel(batchModel);
            }
            return batchVm;
        }

        public async Task DeleteBatch(int id)
        {
            await _unitOfWork.Batch.Delete(id);
            await _unitOfWork.SaveAsync();
        }
        private List<BatchViewModel> ConvertModelListToViewModelList(List<Batch> batchesModel)
        {
            return batchesModel.Select(x => new BatchViewModel(x)).ToList();
        }
    }
}
