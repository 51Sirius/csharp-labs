using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorOne : DeflectorBase
{
    private const int Durability = 2;
    public DeflectorOne(bool isPhoton)
        : base(isPhoton, Durability)
    {
    }
}