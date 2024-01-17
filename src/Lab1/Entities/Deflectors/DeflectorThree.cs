using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorThree : DeflectorBase
{
    private const int Durability = 40;
    public DeflectorThree(bool isPhoton)
        : base(isPhoton, Durability)
    {
    }
}