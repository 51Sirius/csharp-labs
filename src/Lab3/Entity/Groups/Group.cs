using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Adresats.Groups;

public class Group : IAdresat
{
    private Collection<IAdresat> _adresats;

    public Group(Collection<IAdresat> adresats)
    {
        if (adresats == null) throw new ArgumentNullException(nameof(adresats));
        _adresats = adresats;
    }

    public void SendMessage(Message message)
    {
        foreach (IAdresat adresat in _adresats)
        {
            adresat.SendMessage(message);
        }
    }
}