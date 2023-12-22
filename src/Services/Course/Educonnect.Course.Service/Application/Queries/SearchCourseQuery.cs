using AutoMapper;
using CourseGrpcService;
using Educonnect.Course.Service.Context;
using Educonnect.Course.Service.Entitites;
using Educonnect.Course.Service.Models;
using MediatR;
using System.Data.SqlClient;

namespace Educonnect.Course.Service.Application.Queries
{
    public class SearchCourseQuery : IRequest<IEnumerable<CourseSearchEntity>>
    {
        public class SearchCourseQueryHandler : IRequestHandler<SearchCourseQuery, IEnumerable<CourseSearchEntity>>
        {
            private readonly ICourseDbContext _context;
            public SearchCourseQueryHandler(ICourseDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<CourseSearchEntity>> Handle(SearchCourseQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.CourseDataSP();                
                return data;
            }
        }
    }
}
