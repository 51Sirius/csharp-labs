namespace Contracts.Bills;

public abstract record MoneyOperationResult
{
    private MoneyOperationResult() { }
#pragma warning disable CA1034
    public sealed record Success : MoneyOperationResult;

    public sealed record Wrong : MoneyOperationResult;
    public sealed record InsufficientFunds : MoneyOperationResult;
    public sealed record DeniedAces : MoneyOperationResult;
#pragma warning restore CA1034
}