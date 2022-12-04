
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolSoft.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolSoft.ViewModels
{
    public class SemesterViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public List<ProgramSemester>? ProgramSemesters { get; set; }
        public SemesterViewModel() { }

        public SemesterViewModel(Semester model)
        {
            Id = model.Id;
            Name = model.Name;
            ProgramSemesters = model.ProgramSemesters;
        }

        public Semester ConvertViewModel(SemesterViewModel vm )
        {
            return new Semester
            {
                Id = vm.Id,
                Name = vm.Name,
                ProgramSemesters = vm.ProgramSemesters
            };
        }
    }
}
