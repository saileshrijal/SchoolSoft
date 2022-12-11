
using Microsoft.AspNetCore.Http;
using SchoolSoft.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolSoft.ViewModels
{
    public class ParentViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? ConctactNumber { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? PhotoUrl { get; set; }
        public IFormFile? Photo { get; set; }

        public ParentViewModel() { }

        public ParentViewModel(Parent model) // model to vm
        {
            Id = model.Id;
            Name = model.Name;
            Gender = model.Gender;
            ConctactNumber = model.ConctactNumber;
            Email = model.Email;
            CreatedAt = model.CreatedAt; 
            PhotoUrl = model.PhotoUrl;
        }

        public Parent ConvertViewModel(ParentViewModel vm)
        {
            return new Parent
            {
                Id = vm.Id,
                Name = vm.Name,
                Gender = vm.Gender,
                ConctactNumber = vm.ConctactNumber,
                Email = vm.Email,
                CreatedAt = vm.CreatedAt,
                PhotoUrl = vm.PhotoUrl,
            };
        }
    }
}
