using System.Net.Sockets;
using Grpc.Net.Client;

namespace pyrewall.privileged.client;

public class Class1
{
    public static GrpcChannel CreateChannel()
    {
        var udsEndPoint = new UnixDomainSocketEndPoint(Environment.GetEnvironmentVariable("PYREWALL_PRIV_SOCK") ?? "/tmp/pyrewall.sock");
        var connectionFactory = new UnixDomainSocketsConnectionFactory(udsEndPoint);
        var socketsHttpHandler = new SocketsHttpHandler
        {
            ConnectCallback = connectionFactory.ConnectAsync
        };

        return GrpcChannel.ForAddress("http://localhost", new GrpcChannelOptions
        {
            HttpHandler = socketsHttpHandler
        });
    }

    async Task test()
    {
        using var channel = CreateChannel();
        var client = new SystemInfo.SystemInfoClient(channel);
        var hostname = client.GetSystemInfo(new voidNoParam()).Hostname;

    }
}