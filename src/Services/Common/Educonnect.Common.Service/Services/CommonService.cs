//using Educonnect.Common.Service.Application.LeadQualification.Queries;

namespace Educonnect.Common.Service.Services
{
    public class CommonService: CommonBase
    {
        private readonly IMediator _mediator;
        public CommonService(IMediator mediator) => _mediator = mediator;
        public override async Task<AllLookupDataResponse> GetAllLookupData(LookupDataRequest request, ServerCallContext context)
        {
            try
            {
                var response = await _mediator.Send(new GetAllLookupDataQuery());
                AllLookupDataResponse result = new()
                {
                    Items = { response }
                };
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
