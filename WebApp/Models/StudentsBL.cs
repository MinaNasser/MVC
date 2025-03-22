namespace WebApp.Models
{
    public class StudentsBL
    {
        List<Student> students;
        public StudentsBL()
        {
            students = new List<Student>();
            students.Add(
                new Student() {
                    Id=1,
                    Name="Mina" ,
                    Image = "a.png"
                });

            students.Add(
                new Student()
                {
                    Id = 2,
                    Name = "Nasser",
                    Image = "b.jpg"
                });
            students.Add(
                new Student()
                {
                    Id = 3,
                    Name = "Enjilizy",
                    Image = "c.png"
                });
        }
        public List<Student> GetStudents()
        {
            return students;
        }
        public Student GetStudentById(int _id)
        {
            return students.FirstOrDefault(i => i.Id == _id);
        }
    }
}
