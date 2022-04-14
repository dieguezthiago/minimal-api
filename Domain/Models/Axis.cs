namespace Domain.Models;

public class Axis
{
    public int Begin { get; private set; }
    public int End { get; private set; }

    protected Axis()
    {
        
    }
    
    public Axis(int begin, int end)
    {
        Begin = begin;
        End = end;
    }

    public static bool operator ==(Axis axis1, Axis axis2)
        => axis1.Begin == axis2.Begin && axis1.End == axis2.End;

    public static bool operator !=(Axis axis1, Axis axis2)
        => !(axis1 == axis2);

    public override string ToString()
        => $"{Begin} -> {End}";
}