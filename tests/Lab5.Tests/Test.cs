using System.Collections.ObjectModel;
using System.Linq;
using Abstractions.Repository;
using Application.Users;
using Contracts.Bills;
using Infrastructure.DataAccess.Repositories;
using Models.Admins;
using Models.Bill;
using Models.Users;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Test
{
    [Fact]
    public void WithdrawalTest()
    {
        var user = new User(1, "Danil", UserRole.User);
        var bill = new Bill(1, 1, "1234");
        IUserRepository userRepository = new TestUserRepository(new Collection<User>().Append(user));
        bill.Balance = 10;
        IBillRepository billRepository = new TestBillRepository(new Collection<Bill>().Append(bill));
        var userService = new UserService(userRepository, new CurrentUserManager(), billRepository);
        userService.Login("Danil");
        userService.LoginBill(1, "1234");
        userService.GetMoney(10);
        Assert.Equal(0, userService.ShowBalance());
    }

    [Fact]
    public void WithdrawalExceptionTest()
    {
        var user = new User(1, "Danil", UserRole.User);
        var bill = new Bill(1, 1, "1234");
        IUserRepository userRepository = new TestUserRepository(new Collection<User>().Append(user));
        bill.Balance = 10;
        IBillRepository billRepository = new TestBillRepository(new Collection<Bill>().Append(bill));
        var userService = new UserService(userRepository, new CurrentUserManager(), billRepository);
        userService.Login("Danil");
        userService.LoginBill(1, "1234");
        Assert.Equal(new MoneyOperationResult.InsufficientFunds(), userService.GetMoney(100));
    }

    [Fact]
    public void DepositTest()
    {
        var user = new User(1, "Danil", UserRole.User);
        var bill = new Bill(1, 1, "1234");
        IUserRepository userRepository = new TestUserRepository(new Collection<User>().Append(user));
        bill.Balance = 10;
        IBillRepository billRepository = new TestBillRepository(new Collection<Bill>().Append(bill));
        var userService = new UserService(userRepository, new CurrentUserManager(), billRepository);
        userService.Login("Danil");
        userService.LoginBill(1, "1234");
        userService.SendMoney(100);
        Assert.Equal(110, userService.ShowBalance());
    }
}