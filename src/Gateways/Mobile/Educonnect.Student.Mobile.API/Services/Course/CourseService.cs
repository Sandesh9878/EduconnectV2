using CourseGrpcService;

namespace Educonnect.Student.Mobile.API.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly CourseClient _client;
        public CourseService(CourseClient client)
        {
            _client = client;
        }
        public async Task<CourseSearchResponseList> SearchCourseAsync(CourseSearchRequest request)
        {
            //var request = new CourseSearchRequest();
            var response = await _client.GetCourseSearchDataAsync(request);
            return response;
        }
    }
}
