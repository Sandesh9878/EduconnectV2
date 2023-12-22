var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddPersistence(builder.Configuration);
builder.WebHost
      .ConfigureKestrel(options =>
      {
          var ports = GetDefinedPorts(builder.Configuration);
          options.Listen(IPAddress.Any,ports.httpPort, listenOptions =>
           {
               listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
           });
          options.Listen(IPAddress.Any,ports.grpcPort, listenOptions =>
           {
               listenOptions.Protocols = HttpProtocols.Http2;
           });

      });
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddStackExchangeRedisCache(options => {
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "RedisCommon_";
});
var app = builder.Build();
app.MapGrpcService<CommonService>();
app.MapGrpcService<FormService>();
app.Run();

(int httpPort, int grpcPort) GetDefinedPorts(IConfiguration config)
{
    var grpcPort = config.GetValue("GRPC_PORT",5);
    var port = config.GetValue("PORT",6);
    return (port, grpcPort);
}
    