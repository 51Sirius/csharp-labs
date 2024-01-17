namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class NullXmpProfile : XmpProfile
{
    private new const string Timings = " ";
    private new const float Voltage = 0;
    private new const string Frequency = " ";
    public NullXmpProfile()
        : base(Timings, Voltage, Frequency)
    {
    }
}