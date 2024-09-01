using Grpc.Core;

namespace pyrewall.privileged.Services;

public class SystemInfoService : SystemInfo.SystemInfoBase
{
    private readonly ILogger<SystemInfoService> _logger;
    
    public SystemInfoService(ILogger<SystemInfoService> logger)
    {
        _logger = logger;
    }

    public async override Task<SystemInfoResponse> GetSystemInfo(voidNoParam request, ServerCallContext context)
    {
        return new SystemInfoResponse
        {
            Hostname = ""
        };
    }
}