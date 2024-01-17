using Abstractions.Repository;
using Contracts;
using Contracts.Bills;
using Models.Bill;
using Models.Users;

namespace Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repositoryUsers;
    private readonly CurrentUserManager _currentUserManager;
    private readonly IBillRepository _repositoryBills;
    private Bill? _currentBill;

    public UserService(
        IUserRepository repository,
        CurrentUserManager currentUserManager,
        IBillRepository repositoryBills)
    {
        _currentBill = null;
        _repositoryUsers = repository;
        _currentUserManager = currentUserManager;
        _repositoryBills = repositoryBills;
    }

    public LoginResult Login(string username)
    {
        User? user = _repositoryUsers.FindUserByUsername(username);

        if (user is null)
        {
            return new LoginResult.NotFound();
        }

        _currentUserManager.User = user;
        return new LoginResult.Success();
    }

    public MoneyOperationResult SendMoney(float money)
    {
        if (_currentBill == null || _currentUserManager.User == null)
        {
            return new MoneyOperationResult.DeniedAces();
        }

        _currentBill.Balance += money;
        return new MoneyOperationResult.Success();
    }

    public float ShowBalance()
    {
        if (_currentBill == null || _currentUserManager.User == null)
        {
            throw new ArgumentException("Залогиниться нужно");
        }

        return _currentBill.Balance;
    }

    public string ShowOperationHistory()
    {
        throw new NotImplementedException();
    }

    public BillLoginResult LoginBill(long billId, string pinCode)
    {
        if (_currentUserManager.User == null) return new BillLoginResult.Wrong();
        Bill? bill = _repositoryBills.FindBillById(billId);
        if (bill != null && bill.Id == billId && bill.Pin == pinCode)
        {
            _currentBill = bill;
            return new BillLoginResult.Success();
        }

        return new BillLoginResult.Wrong();
    }

    public MoneyOperationResult GetMoney(float money)
    {
        if (_currentBill == null || _currentUserManager.User == null)
        {
            return new MoneyOperationResult.DeniedAces();
        }

        if (_currentBill.Balance - money >= 0)
        {
            _currentBill.Balance -= money;
            return new MoneyOperationResult.Success();
        }

        return new MoneyOperationResult.InsufficientFunds();
    }

    public Bill CreateNewBill(long billId, string pinCode)
    {
        if (_currentUserManager.User == null) throw new ArgumentException("Нужно залогиниться");
        const float baseBalance = 0;
        var bill = new Bill(billId, _currentUserManager.User.Id, pinCode);
        bill.Balance = baseBalance;
        return bill;
    }

    public LoginResult LoginAdmin()
    {
        if (_currentUserManager.User != null && _currentUserManager.User.Role is UserRole.Admin)
        {
            _currentUserManager.IsAdmin = true;
            return new LoginResult.Success();
        }

        return new LoginResult.NotFound();
    }
}