using AutoMapper;
using TutionCenterApp.Entity;
using TutionCenterApp.Model;

namespace TutionCenterApp.Mapper
{
    public class StaffMapper :Profile
    {
        public StaffMapper()
        {
            CreateMap<Staff,StaffModel>().ReverseMap();
        }
    }
}
