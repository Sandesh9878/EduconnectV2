using CourseGrpcService;

namespace Educonnect.Student.Mobile.API.Services.Course
{
    public interface ICourseService
    {
        Task<CourseSearchResponseList> SearchCourseAsync(CourseSearchRequest request);
    }
}
