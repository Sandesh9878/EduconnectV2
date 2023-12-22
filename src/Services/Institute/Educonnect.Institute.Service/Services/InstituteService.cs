namespace Educonnect.Institute.Service.Services
{
    public class InstituteService:InstituteBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public InstituteService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<InstitutesResponse> GetInstitutes(InstituteRequest request, ServerCallContext context)
        {
            var response = await _mediator.Send(new InstituteQuery());
            var lst = _mapper.Map<IEnumerable<InstituteEntity>, IEnumerable<InstituteResponse>>(response);
            InstitutesResponse result = new()
            {
                Items = { lst }
            };
            return result;
        }
    }
}
