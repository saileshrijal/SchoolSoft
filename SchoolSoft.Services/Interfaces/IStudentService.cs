using SchoolSoft.ViewModels;


namespace SchoolSoft.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentViewModel>> GetAllStudents();
        Task<StudentViewModel> GetStudent(int id);
        public Task UpdateStudent(StudentViewModel vm);
        public Task DeleteStudent(int id);
        Task CreateStudent(StudentViewModel vm);
    }
}
