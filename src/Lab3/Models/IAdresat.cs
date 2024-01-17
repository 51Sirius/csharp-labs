using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Adresats;

public interface IAdresat
{
    public void SendMessage(Message message);
}