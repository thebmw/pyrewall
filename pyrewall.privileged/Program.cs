using pyrewall.privileged.Services;

var unixSocketPath = Environment.GetEnvironmentVariable("PYREWALL_PRIV_SOCK") ?? "/tmp/pyrewall.sock"; // TODO fix default socket location

var builder = WebApplication.CreateBuilder(args);


// TODO add logging
builder.WebHost.ConfigureKestrel(options =>
{
    var privilegedHttpPort = Environment.GetEnvironmentVariable("PYREWALL_DEBUG_PRIV_HTTP_PORT");
    
    if (!string.IsNullOrEmpty(privilegedHttpPort))
    {
        var port = int.Parse(privilegedHttpPort);
        options.ListenAnyIP(port);
    }
    else
    {
        options.ListenUnixSocket(unixSocketPath);    
    }
});

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<SystemInfoService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();