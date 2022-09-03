using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolTask.Entities.Configuration
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.Property(s => s.FullName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(s => s.City)
                .IsRequired();

            builder.Property(s => s.Street)
                .IsRequired();

            builder.Property(s => s.Number)
                .IsRequired();

            builder.HasMany(s => s.Students)
                .WithOne(s => s.School)
                .HasForeignKey(s => s.SchoolId);
        }
    }
}
