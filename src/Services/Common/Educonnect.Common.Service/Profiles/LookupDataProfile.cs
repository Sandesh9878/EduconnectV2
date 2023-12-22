namespace Educonnect.Common.Service.Profiles
{
    public class LookupDataProfile : Profile
    {
        public LookupDataProfile()
        {
            AllowNullCollections = false;
            CreateMap<ReferenceMasterDetailEntity, LookupDataResponse>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => $"{src.ReferenceMasterDetailId}")
                )
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom((src, dest) =>
                {
                    if (string.IsNullOrEmpty(src.ReferenceMasterDetail))
                    {
                        return string.Empty;
                    }
                    return $"{src.ReferenceMasterDetail}";
                }
                ))
                .ForMember(
                dest => dest.Value,
                opt => opt.MapFrom((src, dest) =>
                {
                    if (string.IsNullOrEmpty(src.Val))
                    {
                        return string.Empty;
                    }
                    return $"{src.Val}";
                }
                ))
                .ForMember(
                dest => dest.Order,
                opt => opt.MapFrom((src, dest) =>
                {
                    if (src.DisplaySequence == null)
                    {
                        return "0";
                    }
                    return $"{src.DisplaySequence}";
                }
                ));
                     
        }
    }
}
