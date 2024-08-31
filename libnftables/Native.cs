using System.Runtime.InteropServices;

namespace libnftables;

internal static class Native
{
    [DllImport("libnftables.so.1", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr nft_ctx_new(UInt32 flags);
    
    [DllImport("libnftables.so.1", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern void nft_ctx_free(IntPtr ctx);
    
    [DllImport("libnftables.so.1", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern UInt32 nft_ctx_output_get_flags(IntPtr ctx);
    
    [DllImport("libnftables.so.1", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern void nft_ctx_output_set_flags(IntPtr ctx, UInt32 flags);
    
    [DllImport("libnftables.so.1", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern int nft_ctx_output_get_debug(IntPtr ctx);

    [DllImport("libnftables.so.1", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern void nft_ctx_output_set_debug(IntPtr ctx, Int32 flags);
    
    [DllImport("libnftables.so.1", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern int nft_ctx_buffer_output(IntPtr ctx);

    [DllImport("libnftables.so.1", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern int nft_ctx_buffer_error(IntPtr ctx);

    [DllImport("libnftables.so.1", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern int nft_run_cmd_from_buffer(IntPtr ctx, String buffer);

    [DllImport("libnftables.so.1", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern int nft_run_cmd_from_filename(IntPtr ctx, String filename);
    
    [DllImport("libnftables.so.1", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern String nft_ctx_get_output_buffer(IntPtr ctx);
    
    [DllImport("libnftables.so.1", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern String nft_ctx_get_error_buffer(IntPtr ctx);
    
    [DllImport("libnftables.so.1", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool nft_ctx_get_dry_run(IntPtr ctx);
    
    [DllImport("libnftables.so.1", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern void nft_ctx_set_dry_run(IntPtr ctx, bool dry);
}