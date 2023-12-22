using Educonnect.Student.Service.Model;

namespace Educonnect.Student.Service.Application.Queries
{
    public class StudentApplicationQuery : IRequest<StudentApplicationResponseModel>
    {
        public string UserId { get; }
        public StudentApplicationQuery(string userId)
        {
            UserId = userId;
        }
        public class StudentApplicaitonQueryHandler : IRequestHandler<StudentApplicationQuery, StudentApplicationResponseModel>
        {
            private readonly IStudentDbContext _context;

            public StudentApplicaitonQueryHandler(IStudentDbContext context)
            {
                _context = context;
            }

            public async Task<StudentApplicationResponseModel> Handle(StudentApplicationQuery request, CancellationToken cancellationToken)
            {
                //var tempdata = new StudentApplicationResponseModel();
                //tempdata.AppilcationId = (from studentDetail in _context.StudentDetails
                //           join studentApplication in _context.StudentApplications on studentDetail.StudentNo equals studentApplication.StudentNo
                //           where studentDetail.UserRefID == request.UserId
                //           select studentApplication.ApplicationID).ToList();
                //return tempdata;
                try
                {
                    var temp = _context.StudentApplication;
                    var temp2 = _context.StudentDetails.Where(x => x.UserRefID == request.UserId);
                    var tempdata = new StudentApplicationResponseModel();
                    tempdata.AppilcationId = (from studentDetail in _context.StudentDetails.Where(x=>x.UserRefID == request.UserId)
                                              join studentApplication in _context.StudentApplication on studentDetail.StudentNo equals studentApplication.StudentNo
                                              where studentDetail.UserRefID == request.UserId
                                              select studentApplication.ApplicationID).ToList();
                    return tempdata;
                    //var data = await _context.StudentDetails.Select(x => x.StudentId).ToListAsync();
                    //return data.AsQueryable();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
    }
}
