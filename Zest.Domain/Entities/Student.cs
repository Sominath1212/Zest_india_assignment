
namespace Zest.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }
        public string CourseName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
