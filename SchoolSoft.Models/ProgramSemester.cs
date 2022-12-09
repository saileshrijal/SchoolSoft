
namespace SchoolSoft.Models
{
    public class ProgramSemester
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public Program? Program { get; set; }
        public int SemesterId { get; set; }
        public Semester? Semester { get; set; }
    }
}
