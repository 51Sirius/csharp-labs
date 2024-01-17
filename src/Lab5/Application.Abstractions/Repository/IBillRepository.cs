using Models.Bill;

namespace Abstractions.Repository;

public interface IBillRepository
{
    Bill? FindBillById(long billId);
}