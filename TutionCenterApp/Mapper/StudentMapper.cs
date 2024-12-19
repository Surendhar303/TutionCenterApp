using AutoMapper;
using TutionCenterApp.Entity;
using TutionCenterApp.Model;

namespace TutionCenterApp.Mapper
{
    public class StudentMapper :Profile
    {
        public StudentMapper()
        {
            CreateMap<Student,StudentModel>().ReverseMap();
        }
    }
}
