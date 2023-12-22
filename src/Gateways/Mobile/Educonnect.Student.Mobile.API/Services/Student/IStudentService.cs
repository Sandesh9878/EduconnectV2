using StudentGrpcService;

namespace Educonnect.Student.Mobile.API.Services.Student
{
    public interface IStudentService
    {
        Task<StudentsResponse> GetStudents();
        Task<StudentApplicationRespones> GetApplications();
    }
}
