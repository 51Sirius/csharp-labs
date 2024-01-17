using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface IMessageSender
{
    void SendMessage(Message message);
}