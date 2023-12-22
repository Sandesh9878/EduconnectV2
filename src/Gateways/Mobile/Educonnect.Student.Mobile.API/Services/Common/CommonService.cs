namespace Educonnect.Student.Mobile.API.Services.Common
{
    public class CommonService:ICommonService
    {
        private readonly CommonClient _client;
        public CommonService(CommonClient client)
        {
            _client = client;
        }
        public async Task<AllLookupDataResponse> GetAllLookupDataAsync()
        {
            var request = new LookupDataRequest();
            var response = await _client.GetAllLookupDataAsync(request);
            return response;
        }

    }
}
