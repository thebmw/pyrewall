namespace libnftables;

public class CommandResult
{
    public int ResultCode { get; set; }
    public string? Output { get; set; } = null!;
    public string? Error { get; set; } = null!;
}