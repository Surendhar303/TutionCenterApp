using AutoMapper;
using TutionCenterApp.Entity;
using TutionCenterApp.Model;

namespace TutionCenterApp.Mapper
{
    public class DepartmentMapper : Profile
    {
        public DepartmentMapper()
        {
            CreateMap<Department,DepartmentModel>().ReverseMap();
        }
    }
}
