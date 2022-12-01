using SchoolSoft.ViewModels;

namespace SchoolSoft.Services.Interfaces
{
    public interface IFacultyService
    {
        Task<List<FacultyViewModel>> GetAllFaculties();
        Task<FacultyViewModel> GetFaculty(int id);
        public Task UpdateFaculty(FacultyViewModel vm);
        public Task DeleteFaculty(int id);
        Task CreateFaculty(FacultyViewModel vm);
    }
}
