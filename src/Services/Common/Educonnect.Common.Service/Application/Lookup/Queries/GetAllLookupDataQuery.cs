namespace Educonnect.Common.Service.Application.Lookup.Queries
{
    public class GetAllLookupDataQuery : IRequest<IEnumerable<LookupDataResponse>>
    {
        public class GetAllLookupDataQueryHandler : IRequestHandler<GetAllLookupDataQuery, IEnumerable<LookupDataResponse>>
        {
            private readonly ICommonDbContext _context;
            public readonly IMapper _mapper;
            private readonly IDistributedCache _cache;
            public GetAllLookupDataQueryHandler(ICommonDbContext context, IMapper mapper, IDistributedCache cache)
            {
                _context = context;
                _mapper = mapper;
                _cache=cache;
            }
            public async Task<IEnumerable<LookupDataResponse>> Handle(GetAllLookupDataQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    IEnumerable<LookupDataResponse>? lookupData;
                    string recordKey = "LookupKey";
                    lookupData = await _cache.GetRecordAsync<List<LookupDataResponse>>(recordKey);
                    if (lookupData is null)
                    {
                       lookupData = _mapper.Map<IEnumerable<ReferenceMasterDetailEntity>, IEnumerable<LookupDataResponse>>(_context.ReferenceMasterDetail.ToList());
                       await _cache.SetRecordAsync(recordKey, lookupData);
                    }
                    return lookupData.Take(10);
                }
                catch (SqlException ex)
                {

                    throw ex;
                }
                
            }
        }
    }
}
