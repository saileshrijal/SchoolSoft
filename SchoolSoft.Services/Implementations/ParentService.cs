using SchoolSoft.Models;
using SchoolSoft.Repositories.Interfaces;
using SchoolSoft.Services.Interfaces;
using SchoolSoft.ViewModels;


namespace SchoolSoft.Services.Implementations
{
    public class ParentService: IParentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateParent(ParentViewModel vm)
        {
            var parentModel = new ParentViewModel().ConvertViewModel(vm);
            await _unitOfWork.Parent.Create(parentModel);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateParent(ParentViewModel vm)
        {
            var parentModel = new ParentViewModel().ConvertViewModel(vm);
            var existingParent = await _unitOfWork.Parent.GetBy(x => x.Id == parentModel.Id);
            existingParent.Name = vm.Name;
            existingParent.Gender = vm.Gender;
            existingParent.ConctactNumber = vm.ConctactNumber;
            existingParent.Email = vm.Email;
            await _unitOfWork.SaveAsync();
        }
        public async Task<List<ParentViewModel>> GetAllParents()
        {
            var ParentModel = await _unitOfWork.Parent.GetAll();
            var ParentsVM = ConvertModelListToViewModelList(ParentModel);
            return ParentsVM;
        }
        public async Task<ParentViewModel> GetParent(int id)
        {
            var parentVm = new ParentViewModel();//create null object
            var parentModel = await _unitOfWork.Parent.GetBy(x => x.Id == id);
            if (parentModel != null)
            {
                parentVm = new ParentViewModel(parentModel);
            }
            return parentVm;
        }

        public async Task DeleteParent(int id)
        {
            await _unitOfWork.Parent.Delete(id);
            await _unitOfWork.SaveAsync();
        }
        private List<ParentViewModel> ConvertModelListToViewModelList(List<Parent> parentsModel)
        {
            return parentsModel.Select(x => new ParentViewModel(x)).ToList();
        }
       
    }
}
