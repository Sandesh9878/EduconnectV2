using Educonnect.Student.Service.Model;

namespace Educonnect.Student.Service.Services
{
    public class StudentService : StudentBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public StudentService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<StudentsResponse> GetStudents(StudentRequest request, ServerCallContext context)
        {
            var response = await _mediator.Send(new StudentQuery());
            var lst = _mapper.Map<IEnumerable<StudentEntity>, IEnumerable<StudentResponse>>(response);
            StudentsResponse result = new()
            {
                Items = { lst }
            };
            return result;
        }
        public override async Task<StudentApplicationRespones> GetApplications(StudentApplicationRequest request, ServerCallContext context)
        {
            var response = await _mediator.Send(new StudentApplicationQuery(request.UserId));
            try
            {
                var data = _mapper.Map<StudentApplicationResponseModel, StudentApplicationRespones>(response);
                return data;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
