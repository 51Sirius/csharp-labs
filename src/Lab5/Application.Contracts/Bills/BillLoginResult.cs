namespace Contracts.Bills;

public abstract record BillLoginResult
{
    private BillLoginResult() { }
#pragma warning disable CA1034
    public sealed record Success : BillLoginResult;

    public sealed record Wrong : BillLoginResult;
#pragma warning restore CA1034
}