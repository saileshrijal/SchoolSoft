using SchoolSoft.Models;
using System.ComponentModel.DataAnnotations;


namespace SchoolSoft.ViewModels
{
    public class FacultyViewModel
    {
        public int id { get; set; }

        [Required]
        public string? name { get; set; }
        public string? description { get; set; }

        public FacultyViewModel()
        {
        }

        public FacultyViewModel(Faculty model) // model to vm
        {
            id = model.Id;
            name = model.Name;
            description = model.Description;
        }

        public Faculty ConvertViewModel(FacultyViewModel vm)
        {
            return new Faculty
            {
                Id = vm.id,
                Name = vm.name,
                Description = vm.description
            };
        }

    }
}
