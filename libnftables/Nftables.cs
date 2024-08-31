using System.Runtime.InteropServices;

namespace libnftables;

public class Nftables : IDisposable
{
    private IntPtr _ctx;

    public Nftables()
    {
        _ctx = Native.nft_ctx_new(0);
        Console.WriteLine($"{_ctx:X}");
        var output = Native.nft_ctx_buffer_output(_ctx);
        var error = Native.nft_ctx_buffer_error(_ctx);
    }

    public void Dispose()
    {
        Native.nft_ctx_free(_ctx);
        GC.SuppressFinalize(this);
    }

    private bool GetOutputFlag(NftablesOutputFlags flag)
    {
        var val = Native.nft_ctx_output_get_flags(_ctx) & (uint)flag;
        return val != 0;
    }

    private void SetOutputFlag(NftablesOutputFlags flag, Boolean value)
    {
        var f = (uint)flag;
        var flags = Native.nft_ctx_output_get_flags(_ctx);
        var newFlags = flags;
        if (value)
        {
            newFlags |= f;
        }
        else
        {
            newFlags &= ~f;
        }
        Native.nft_ctx_output_set_flags(_ctx, newFlags);
    }

    public Boolean ReverseDnsOutput
    {
        get => GetOutputFlag(NftablesOutputFlags.ReverseDNS);
        set => SetOutputFlag(NftablesOutputFlags.ReverseDNS, value);
    }

    public Boolean JsonOutput
    {
        get => GetOutputFlag(NftablesOutputFlags.Json);
        set => SetOutputFlag(NftablesOutputFlags.Json, value);
    }

    public CommandResult RunCommand(string commandLine)
    {
        var rc = Native.nft_run_cmd_from_buffer(_ctx, commandLine);
        var output = Native.nft_ctx_get_output_buffer(_ctx);
        var error = Native.nft_ctx_get_error_buffer(_ctx);
        var result = new CommandResult()    
        {
            ResultCode = rc,
            Output = Marshal.PtrToStringAnsi(output),
            Error = Marshal.PtrToStringAnsi(error)  
        };
        
        return result;
    }
    
    public CommandResult RunCommandFromFile(string filename)
    {
        var rc = Native.nft_run_cmd_from_filename(_ctx, filename);
        var output = Native.nft_ctx_get_output_buffer(_ctx);
        var error = Native.nft_ctx_get_error_buffer(_ctx);
        var result = new CommandResult()
        {
            ResultCode = rc,
            Output = Marshal.PtrToStringAnsi(output),
            Error = Marshal.PtrToStringAnsi(error)  
        };
        
        return result;
    }
}