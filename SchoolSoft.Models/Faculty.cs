namespace SchoolSoft.Models
{
    public class Faculty
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Program>? Programs { get; set; }
    }
}
