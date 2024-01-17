using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Service;
#pragma warning disable IDE0005
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Adresats.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Adresats.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Service.Loggers;
#pragma warning restore IDE0005
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Test
{
    [Fact]
    public void MessegeIsUnRead()
    {
        Message message = new MessageBuilder().SetBody("Я люблю ооп").SetTitle("А").SetImportanceLevel(0).Build();
        var user = new User("Danya");
        var userAdresat = new UserAdresat(user, new ConsoleLogger());
        userAdresat.SendMessage(message);
        Assert.True(!user.IsReadMessage(message));
    }

    [Fact]
    public void MessegeReading()
    {
        Message message = new MessageBuilder().SetBody("Я люблю ооп").SetTitle("А").SetImportanceLevel(0).Build();
        var user = new User("Danya");
        var userAdresat = new UserAdresat(user, new ConsoleLogger());
        userAdresat.SendMessage(message);
        user.MarkMessageAsRead(message);
        Assert.True(user.IsReadMessage(message));
    }

    [Fact]
    public void MessegeReadingExepction()
    {
        Message message = new MessageBuilder().SetBody("Я люблю ооп").SetTitle("А").SetImportanceLevel(0).Build();
        var user = new User("Danya");
        var userAdresat = new UserAdresat(user, new ConsoleLogger());
        userAdresat.SendMessage(message);
        user.MarkMessageAsRead(message);
        Assert.Throws<ArgumentException>(() => user.MarkMessageAsRead(message));
    }

    [Fact]
    public void LogMessage()
    {
        var mockLogger = new MockLogger();
        var user = new User("Danya");
        var userAdresat = new UserAdresat(user, mockLogger);
        Message message = new MessageBuilder().SetBody("Я люблю ооп").SetTitle("А").SetImportanceLevel(1).Build();
        userAdresat.SendMessage(message);
        Assert.Equal("Пользователь", mockLogger.LastLoggedName);
        Assert.Equal($"Получил сообщение {message.Title}", mockLogger.LastLoggedMessage);
    }

    [Fact]
    public void FilterMessage()
    {
        var mockLogger = new MockLogger();
        var user = new User("Danya");
        var userAdresat = new UserAdresat(user, mockLogger);
        var userFilterAdresat = new Filter(userAdresat, 2, mockLogger);
        Message message = new MessageBuilder().SetBody("Я люблю ооп").SetTitle("А").SetImportanceLevel(1).Build();
        userFilterAdresat.SendMessage(message);
        Assert.Equal("Адресат", mockLogger.LastLoggedName);
        Assert.Equal($"Не получил сообщение {message.Title}, т.к. недостаточный уровень важности", mockLogger.LastLoggedMessage);
    }

    [Fact]
    public void LogMessageForMessanger()
    {
        var mockLogger = new MockLogger();
        var messenger = new Messenger("VK", new MessengerConsole());
        var messengerAdresat = new MessengerAdresat(mockLogger, messenger);
        Message message = new MessageBuilder().SetBody("Я люблю ооп").SetTitle("А").SetImportanceLevel(1).Build();
        messengerAdresat.SendMessage(message);
        Assert.Equal("Мессенджер", mockLogger.LastLoggedName);
        Assert.Equal($"Получил сообщение {message.Title}", mockLogger.LastLoggedMessage);
    }
}