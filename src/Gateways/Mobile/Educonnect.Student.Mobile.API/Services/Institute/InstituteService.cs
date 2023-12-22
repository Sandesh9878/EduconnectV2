using InstituteGrpcService;

namespace Educonnect.Student.Mobile.API.Services.Institute
{
    public class InstituteService:IInstituteService
    {
        private readonly InstituteClient _client;
        public InstituteService(InstituteClient client)
        {
            _client = client;
        }
        public async Task<InstitutesResponse> GetInstitutes()
        {
            var response = await _client.GetInstitutesAsync(new InstituteRequest());
            return response;
        }
    }
}
