
using Microsoft.VisualBasic;
using SchoolSoft.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolSoft.ViewModels
{
    public class BatchViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public BatchViewModel()
        {
        }
        public BatchViewModel(Batch model) // model to vm
        {
            Id = model.Id;
            Name = model.Name;
            StartDate = model.StartDate;
            EndDate = model.EndDate;
        }

        public Batch ConvertViewModel(BatchViewModel vm)
        {
            return new Batch
            {
                Id = vm.Id,
                Name = vm.Name,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
            };
        }
    }
}
