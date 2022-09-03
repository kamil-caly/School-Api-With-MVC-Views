namespace SchoolTask.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentIndex { get; set; }
        public virtual School School { get; set; }
        public int SchoolId { get; set; }

    }
}
