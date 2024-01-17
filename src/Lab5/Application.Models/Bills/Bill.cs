namespace Models.Bill;

public record Bill(long Id, long UserId, string Pin)
{
    public float Balance { get; set; }
}