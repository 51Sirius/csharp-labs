using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Message;

public class Message
{
    public Message(StatusType status, string comment)
    {
        Status = status;
        Comment = comment;
    }

    public StatusType Status { get; set; }
    public string Comment { get; set; }
}