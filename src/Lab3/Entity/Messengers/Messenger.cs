using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Adresats.Messengers;

public class Messenger
{
    private string _messengerName;
    private IMessengerConsole _console;

    public Messenger(string messengerName, IMessengerConsole console)
    {
        _messengerName = messengerName;
        _console = console;
    }

    public void SendMessage(Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        _console.DisplayMessage($"[Messenger] {message.Title}: {message.Body}");
    }
}