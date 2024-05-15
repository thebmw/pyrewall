namespace libnftables;

[Flags]
public enum NftablesOutputFlags : UInt32
{
    ReverseDNS = (1 << 0),
    Service = (1 << 1),
    Stateless = (1 << 2),
    Handle = (1 << 3),
    Json = (1 << 4),
    Echo = (1 << 5),
    Guid = (1 << 6),
    NumericProto = (1 << 7),
    NumericPrio = (1 << 8),
    NumericSymbol = (1 << 9),
    NumericTime = (1 << 10),

    NumericAll = (NumericProto |
                  NumericPrio |
                  NumericSymbol |
                  NumericTime),
    Terse = (1 << 11),
}