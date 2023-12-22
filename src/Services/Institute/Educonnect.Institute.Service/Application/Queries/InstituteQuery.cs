namespace Educonnect.Institute.Service.Application.Queries
{
    public class InstituteQuery : IRequest<IQueryable<InstituteEntity>>
    {
        public class InstituteQueryHandler : IRequestHandler<InstituteQuery, IQueryable<InstituteEntity>>
        {
            private readonly IInstituteDbContext _context;
            public InstituteQueryHandler(IInstituteDbContext context)
            {
                _context = context;
            }
            public async Task<IQueryable<InstituteEntity>> Handle(InstituteQuery request, CancellationToken cancellationToken)
            {
                var data = _context.Institute;
                return data;
            }
        }
    }
}
