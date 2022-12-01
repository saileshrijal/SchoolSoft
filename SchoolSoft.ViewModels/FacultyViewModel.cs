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
            id = model.id;
            name = model.name;
            description = model.description;
        }

        public Faculty ConvertViewModel(FacultyViewModel model)
        {
            return new Faculty
            {
                id = model.id,
                name = model.name,
                description = model.description
            };
        }

    }
}
