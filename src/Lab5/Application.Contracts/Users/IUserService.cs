using Contracts.Bills;
using Models.Bill;

namespace Contracts;

public interface IUserService
{
    LoginResult Login(string username);
    MoneyOperationResult SendMoney(float money);
    float ShowBalance();
    string ShowOperationHistory();
    BillLoginResult LoginBill(long billId, string pinCode);
    MoneyOperationResult GetMoney(float money);
    Bill CreateNewBill(long billId, string pinCode);
    LoginResult LoginAdmin();
}