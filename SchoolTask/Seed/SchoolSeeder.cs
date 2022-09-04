using Bogus;
using SchoolTask.Entities;

namespace SchoolTask.Seed
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
                    dbContext.AddRange(GetSampleData());
                    dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<School> GetSampleData()
        {
            var schoolGenerator = new Faker<School>()
                .RuleFor(s => s.FullName, f => f.Company.CompanyName())
                .RuleFor(s => s.City, f => f.Address.City())
                .RuleFor(s => s.Street, f => f.Address.StreetAddress())
                .RuleFor(s => s.Number, f => f.Address.BuildingNumber())
                .RuleFor(s => s.SchoolType, f => f.Company.CompanySuffix())
                .RuleFor(s => s.Students, f => this.GetStudents());

            var schools = schoolGenerator.Generate(5);
            return schools;
        }

        private IEnumerable<Student> GetStudents()
        {
            var studentGenerator = new Faker<Student>()
                .RuleFor(s => s.Name, f => f.Person.FirstName)
                .RuleFor(s => s.Surname, f => f.Person.LastName)
                .RuleFor(s => s.StudentIndex, f => f.Random.Int(100000, 999999).ToString());

            var students = studentGenerator.Generate(100);

            return students;
        }
    }
}
