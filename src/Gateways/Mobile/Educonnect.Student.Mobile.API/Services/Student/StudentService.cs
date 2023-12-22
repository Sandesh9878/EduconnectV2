using StudentGrpcService;
using System.Security.Claims;
using static StudentGrpcService.Student;

namespace Educonnect.Student.Mobile.API.Services.Student
{
    public class StudentService: IStudentService
    {
        private readonly StudentClient _client;
        private IAppSession _appSession;
        public StudentService(StudentClient client, IAppSession appSession)
        {
            _client = client;
            _appSession = appSession;
        }
        public async Task<StudentsResponse> GetStudents()
        {
            var response = await _client.GetStudentsAsync(new StudentRequest());
            return response;
        }
        public async Task<StudentApplicationRespones> GetApplications()
        {
            var usId = _appSession.UserId;
            var response = await _client.GetApplicationsAsync(new StudentApplicationRequest
            {
                UserId = _appSession.UserId,
            });
            return response;
        }
    }
}
