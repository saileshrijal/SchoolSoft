using SchoolSoft.Models;
using SchoolSoft.Repositories.Interfaces;
using SchoolSoft.Services.Interfaces;
using SchoolSoft.ViewModels;


namespace SchoolSoft.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateStudent(StudentViewModel vm)
        {
            var studentModel = new StudentViewModel().ConvertViewModel(vm);
            await _unitOfWork.Student.Create(studentModel);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateStudent(StudentViewModel vm)
        {
            var studentModel = new StudentViewModel().ConvertViewModel(vm);
            var existingStudent = await _unitOfWork.Student.GetBy(x => x.Id == studentModel.Id);
            existingStudent.Name = vm.Name;
            existingStudent.Address = vm.Address;
            existingStudent.Email = vm.Email;
            await _unitOfWork.SaveAsync();
        }


        public async Task<List<StudentViewModel>> GetAllStudents()
        {
            var studentsModel = await _unitOfWork.Student.GetAll();
            var studentsVM = ConvertModelListToViewModelList(studentsModel);
            return studentsVM;
        }

        public async Task DeleteStudent(int id)
        {
            await _unitOfWork.Student.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<StudentViewModel> GetStudent(int id)
        {
            var studentVM = new StudentViewModel();//create null object
            var studentModel = await _unitOfWork.Student.GetBy(x => x.Id == id);
            if (studentModel != null)
            {
                studentVM = new StudentViewModel(studentModel);
            }
            return studentVM;
        }


        //user defined fuction
        private List<StudentViewModel> ConvertModelListToViewModelList(List<Student> studentsModel)
        {
            return studentsModel.Select(x => new StudentViewModel(x)).ToList();
        }
    }
}
