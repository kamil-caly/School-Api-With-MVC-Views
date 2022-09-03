using AutoMapper;
using SchoolTask.Entities;
using SchoolTaskModels.Dtos;

namespace SchoolTask.Mapping
{
    public class SchoolMapingProfile : Profile
    {
        public SchoolMapingProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<CreateStudentDto, Student>();

            CreateMap<School, SchoolDto>();
            CreateMap<CreateSchoolDto, School>();
            CreateMap<UpdateSchoolDto, School>();
        }
    }
}
