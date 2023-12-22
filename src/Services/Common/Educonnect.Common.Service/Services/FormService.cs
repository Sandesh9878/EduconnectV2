namespace Educonnect.Common.Service.Services
{
    public class FormService : FormBufBase
    {
        private readonly IMediator _mediator;
        public FormService(IMediator mediator) => _mediator = mediator;
        public override async Task<AllLeadQualificationData> GetLeadQuestionAnswers(Empty request, ServerCallContext context)
        {
            try
            {
                var response = await _mediator.Send(new GetLeadQuestionAnswersQuery());
                AllLeadQualificationData result = new()
                {
                    Questions = { response }
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
