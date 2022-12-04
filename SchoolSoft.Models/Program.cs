namespace SchoolSoft.Models
{
    public class Program
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public List<ProgramSemester>? ProgramSemesters { get; set; }
    }
}
