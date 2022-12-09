using SchoolSoft.ViewModels;

namespace SchoolSoft.Services.Interfaces
{
    public interface IParentService
    {
        public Task CreateParent(ParentViewModel vm);
        public Task UpdateParent(ParentViewModel vm);
        Task<List<ParentViewModel>> GetAllParents();
        Task<ParentViewModel> GetParent(int id);
        public Task DeleteParent(int id);
    }
}
