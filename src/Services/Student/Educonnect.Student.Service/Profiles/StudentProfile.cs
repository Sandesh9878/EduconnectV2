using Educonnect.Student.Service.Model;

namespace Educonnect.Student.Service.Profiles
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentEntity, StudentResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<StudentApplicationRespones, StudentApplicationResponseModel>().ForMember(
                dest => dest.AppilcationId,
                opt => opt.MapFrom(src => $"{src.ApplicationId}")
                );
        }
    }
}
