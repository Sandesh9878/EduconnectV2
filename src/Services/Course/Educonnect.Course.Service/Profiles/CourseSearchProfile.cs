using AutoMapper;
using CourseGrpcService;
using Educonnect.Course.Service.Entitites;
using Educonnect.Course.Service.Models;

namespace Educonnect.Course.Service.Profiles
{
    public class CourseSearchProfile: Profile
    {
        public CourseSearchProfile()
        {
            CreateMap<CourseSearchEntity, CourseSearchResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CourseSearchEntity, CourseSearchModel>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
