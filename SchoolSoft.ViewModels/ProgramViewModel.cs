using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolSoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoft.ViewModels
{
    public class ProgramViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public int FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public List<SelectListItem>? Faculties { get; set; }

        public ProgramViewModel()
        {
        }

        public ProgramViewModel(Program model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            FacultyId = model.FacultyId;
            Faculty = model.Faculty;
        }

        public Program ConvertViewModel(ProgramViewModel vm)
        {
            return new Program
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                FacultyId = vm.FacultyId,
                Faculty = vm.Faculty,
            };
        }
    }
}
