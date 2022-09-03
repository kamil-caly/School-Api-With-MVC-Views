namespace SchoolTask.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string SchoolType { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}
