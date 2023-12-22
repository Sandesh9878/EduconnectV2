namespace Educonnect.Institute.Service.Profiles
{
    public class InstituteProfile:Profile
    {
        public InstituteProfile()
        {
            CreateMap<InstituteEntity, InstituteResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
