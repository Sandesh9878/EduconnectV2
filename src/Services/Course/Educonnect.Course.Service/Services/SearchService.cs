using AutoMapper;
using CourseGrpcService;
using Educonnect.Course.Service.Application.Queries;
using Educonnect.Course.Service.Entitites;
using Educonnect.Course.Service.Models;
using Educonnect.Course.Service.SearchEngine;
using Grpc.Core;
using MediatR;
using static CourseGrpcService.Course;
namespace Educonnect.Course.Service.Services
{
    public class SearchService : CourseBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public SearchService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<CourseSearchResponseList> GetCourseSearchData(CourseSearchRequest request, ServerCallContext context)
        {
            var response = await _mediator.Send(new SearchCourseQuery());
            var lst = _mapper.Map<IEnumerable<CourseSearchEntity>, IEnumerable<CourseSearchResponse>>(response);
            //var lst1 = _mapper.Map<IEnumerable<CourseSearchEntity>, IEnumerable<CourseSearchModel>>(response);
            CourseSearchResponseList result = new()
            {
                Items = { lst }
            };
            //LuceneSearch<CourseSearchModel>.ClearLuceneIndex();
            //LuceneSearch<CourseSearchModel>.AddUpdateLuceneIndex(lst1);
            var a = LuceneSearch<CourseSearchModel>.Search(new CourseSearchParamModel() {SearchText= request.SearchText}).ToList();
            return result;
        }
    }
}
