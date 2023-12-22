using Educonnect.Core.Authentication;
using Educonnect.Student.Mobile.API.Services.Institute;
using Educonnect.Student.Mobile.API.Services.Student;
using static StudentGrpcService.Student;
using Educonnect.Student.Mobile.API.Services.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddJWTTokenServices(builder.Configuration);
builder.Services.ConfigureSwagger();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpcServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGrpcServices(this IServiceCollection services)
    {
        services.AddTransient<GrpcExceptionInterceptor>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IAppSession, AppSession>();
        services.AddScoped<ICommonService, CommonService>();
        services.AddScoped<IFormService, Educonnect.Student.Mobile.API.Services.Common.FormServices.FormService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IInstituteService, InstituteService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddGrpcClient<CommonClient>((services, options) =>
        {
            options.Address = new Uri("http://common-service:81");
        }).AddInterceptor<GrpcExceptionInterceptor>();
        services.AddGrpcClient<FormBufClient>((services, options) =>
        {
            options.Address = new Uri("http://common-service:81");
        }).AddInterceptor<GrpcExceptionInterceptor>();
        services.AddGrpcClient<CourseClient>((services, options) =>
        {
            options.Address = new Uri("http://course-service:81");
        }).AddInterceptor<GrpcExceptionInterceptor>();
        services.AddGrpcClient<InstituteClient>((services, options) =>
        {
            options.Address = new Uri("http://institute-service:81");
        }).AddInterceptor<GrpcExceptionInterceptor>();
        services.AddGrpcClient<StudentClient>((services, options) =>
        {
            options.Address = new Uri("http://student-service:81");
        }).AddInterceptor<GrpcExceptionInterceptor>();
        return services;
    }

}