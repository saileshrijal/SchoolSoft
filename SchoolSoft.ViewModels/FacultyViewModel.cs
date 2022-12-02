using SchoolSoft.Models;
using System.ComponentModel.DataAnnotations;


namespace SchoolSoft.ViewModels
{
    public class FacultyViewModel
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

        public FacultyViewModel()
        {
        }

        public FacultyViewModel(Faculty model) // model to vm
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
        }

        public Faculty ConvertViewModel(FacultyViewModel vm)
        {
            return new Faculty
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description
            };
        }

    }
}
