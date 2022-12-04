using System.ComponentModel.DataAnnotations;


namespace SchoolSoft.Models
{
    public class Semester
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public List<ProgramSemester>? ProgramSemesters { get; set; }
    }
}
