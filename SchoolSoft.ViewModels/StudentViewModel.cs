using SchoolSoft.Models;


namespace SchoolSoft.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

        public StudentViewModel()
        {
        }

        public StudentViewModel(Student model) 
        {
            Id = model.Id;
            Name = model.Name;
            Address = model.Address;
            Email = model.Email;
        }

        public Student ConvertViewModel(StudentViewModel vm)
        {
            return new Student
            {
                Id = vm.Id,
                Name = vm.Name,
                Address = vm.Address,
                Email = vm.Email,
            };
        }
    }

   
}
