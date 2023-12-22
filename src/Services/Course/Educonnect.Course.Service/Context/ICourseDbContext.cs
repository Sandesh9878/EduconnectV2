using Educonnect.Course.Service.Entitites;
using Educonnect.Course.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Educonnect.Course.Service.Context
{
    public interface ICourseDbContext
    {
        DbSet<CourseSearchEntity> InstituteCourse { get; set; }
        Task<IEnumerable<CourseSearchEntity>> CourseDataSP();
        Task<int> SaveChangesAsync();
    }
}
