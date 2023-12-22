namespace Educonnect.Common.Service.Profiles
{
    public class LeadQualificationOptionProfile : Profile
    {
        public LeadQualificationOptionProfile()
        {
            AllowNullCollections = false;
            CreateMap<FormEntityOption, LeadQualificationOptions>()
                .ForMember(
                    dest => dest.Title,
                    opt => opt.MapFrom(src => $"{src.Title}")
                )
                .ForMember(
                    dest => dest.Score,
                    opt => opt.MapFrom((src, dest) =>
                    {
                        if (src.Score == null)
                        {
                            return string.Empty;
                        }
                        return $"{src.Score.Value}";
                    })
                )
                .ForMember(
                    dest => dest.IsSendEmail,
                    opt => opt.MapFrom(src => $"{src.SendEmail}")
                )
                .ForMember(
                    dest => dest.DisplaySequence,
                    opt => opt.MapFrom((src, dest) =>
                    {
                        if (src.DisplaySequence == null)
                        {
                            return string.Empty;
                        }
                        return $"{src.DisplaySequence.Value}";
                    })
                )
                .ForMember(
                    dest => dest.CurrentStep,
                    opt => opt.MapFrom((src, dest) =>
                    {
                        if (src.CurrentStep == null)
                        {
                            return string.Empty;
                        }
                        return $"{src.CurrentStep.Value}";
                    })
                )
                .ForMember(
                    dest => dest.NextStep,
                    opt => opt.MapFrom((src, dest) =>
                    {
                        if (src.NextStep == null)
                        {
                            return string.Empty;
                        }
                        return $"{src.NextStep.Value}";
                    })
                )
                .ForMember(
                    dest => dest.IsSupportiveTextRequired,
                    opt => opt.MapFrom(src => $"{src.SupportiveTextRequired}")
                )
                ;

        }
    }
}
