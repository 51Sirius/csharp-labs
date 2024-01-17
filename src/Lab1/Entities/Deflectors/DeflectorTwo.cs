using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorTwo : DeflectorBase
{
    private const int Durability = 10;
    public DeflectorTwo(bool isPhoton)
        : base(isPhoton, Durability)
    {
    }
}