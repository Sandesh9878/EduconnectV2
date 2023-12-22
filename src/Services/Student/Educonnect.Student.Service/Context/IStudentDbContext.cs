namespace Educonnect.Student.Service.Context
{
    public interface IStudentDbContext
    {
        DbSet<StudentEntity> Person { get; set; }
        DbSet<StudentApplication> StudentApplication { get; set; }
        DbSet<StudentDetails> StudentDetails { get; set; }
        Task<int> SaveChangesAsync();
    }
}
