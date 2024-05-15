namespace libnftables;

public class CommandResult
{
    public int ResultCode { get; set; }
    public String Output { get; set; } = null!;
    public String Error { get; set; } = null!;
}