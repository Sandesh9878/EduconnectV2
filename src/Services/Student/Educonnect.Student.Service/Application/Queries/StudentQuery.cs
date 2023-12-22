namespace Educonnect.Student.Service.Application.Queries
{
    public class StudentQuery : IRequest<IQueryable<StudentEntity>>
    {
        public class StudentQueryHandler : IRequestHandler<StudentQuery, IQueryable<StudentEntity>>
        {
            private readonly IStudentDbContext _context;
            public StudentQueryHandler(IStudentDbContext context)
            {
                _context = context;
            }
            public async Task<IQueryable<StudentEntity>> Handle(StudentQuery request, CancellationToken cancellationToken)
            {
                var data = _context.Person;
                return data;
            }
        }
    }
}
