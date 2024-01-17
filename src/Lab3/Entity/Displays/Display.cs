using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Adresats.Displays;

public class Display
{
    private DisplayDriver.DisplayDriver _displayDriver;

    public Display(DisplayDriver.DisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void SendMessage(Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        _displayDriver.Clear();
        _displayDriver.DisplayColoredText(message.Body);
    }
}