using SchoolTask.Entities;

namespace SchoolTask
{
    public class SchoolSeeder
    {
        private readonly SchoolDbContext dbContext;

        public SchoolSeeder(SchoolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Seed()
        {
            if (dbContext.Database.CanConnect())
            {
                if (!dbContext.Schools.Any())
                {
                    dbContext.AddRange(GetSchools());
                    dbContext.SaveChanges();
                }

                if (dbContext.Students.Count() < 15)
                {
                    dbContext.AddRange(GetStudents());
                    dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<School> GetSchools()
        {
            var schools = new List<School>()
            {
                new School()
                {
                    FullName = "First School",
                    City = "Wrocław",
                    Street = "Polna 32",
                    Number = "3A",
                    SchoolType = "private",
                    Students = new List<Student>()
                    {
                        new Student()
                        {
                            Name = "Marek",
                            Surname = "Nowowiejski",
                            StudentIndex = "224455"
                        },
                        new Student()
                        {
                            Name = "Piotr",
                            Surname = "Kowalski",
                            StudentIndex = "674512"
                        }
                    }
                },

                new School()
                {
                    FullName = "Second School",
                    City = "Warszawa",
                    Street = "Krótka 23",
                    Number = "4F",
                    SchoolType = "public",
                    Students = new List<Student>()
                    {
                        new Student()
                        {
                            Name = "Mirosław",
                            Surname = "Pietraszewski",
                            StudentIndex = "125567"
                        },
                    }
                }
            };
            return schools;
        }

        private IEnumerable<Student> GetStudents()
        {
            var students = new List<Student>()
            {
                new Student()
                {
                    SchoolId = 5,
                    Name = "Mikołaj",
                    Surname = "Niski",
                    StudentIndex = "234567"
                }
            };
            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                students.Add(
                    new Student()
                    {
                        SchoolId = 5,
                        Name = Guid.NewGuid().ToString(),
                        Surname = Guid.NewGuid().ToString(),
                        StudentIndex = random.Next(100000, 999999).ToString()
                    }); 
            }

            return students;
        }
    }
}
