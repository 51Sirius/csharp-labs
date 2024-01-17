using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Users;

public class User
{
    private string _username;
    private Collection<Message> _receivedMessages;
    private Collection<Message> _readMessage;

    public User(string username)
    {
        _username = username;
        _receivedMessages = new Collection<Message>();
        _readMessage = new Collection<Message>();
    }

    public void Send(Message message)
    {
        _receivedMessages.Add(message);
    }

    public void MarkMessageAsRead(Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        if (_receivedMessages.Contains(message))
        {
            if (!_readMessage.Contains(message))
            {
                _readMessage.Add(message);
            }
            else
            {
                throw new ArgumentException("Пользователь уже прочитал это сообщение");
            }
        }
        else
        {
            throw new ArgumentException("Пользольватель не получал таких сообщений");
        }
    }

    public bool IsReadMessage(Message message)
    {
        return _readMessage.Contains(message);
    }
}