using AutoMapper;
using domainmodel=RollOff_Test4API.Models.Domain;
using RollOff_Test4API.Models.DTO;

namespace RollOff_Test4API.Profiles
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<domainmodel.Employee, GetEmployee>()
                .ReverseMap();
            CreateMap<domainmodel.Employee, GetEmployeeByID>()
                .ReverseMap();
            CreateMap<domainmodel.feedbackform, feedbackformdto>()
                  .ReverseMap();

        }
    }
}
