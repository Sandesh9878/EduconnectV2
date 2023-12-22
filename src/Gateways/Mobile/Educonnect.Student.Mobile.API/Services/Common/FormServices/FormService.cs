namespace Educonnect.Student.Mobile.API.Services.Common.FormServices
{
    public class FormService : IFormService 
    {
        private readonly FormBufClient _client;
        public FormService(FormBufClient client)
        {
            _client = client;
        }
        public async Task<AllLeadQualificationData> GetAllLeadDataAsync()
        {
            var response = await _client.GetLeadQuestionAnswersAsync(new Empty());
            return response;
        }
    }
}
