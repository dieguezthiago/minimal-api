namespace Domain.Models;

public class Direction
{
    public static readonly Direction North = new("North", new Position(1, 0));
    public static readonly Direction East = new("East", new Position(0, 1));
    public static readonly Direction South = new("South", new Position(-1, 0));
    public static readonly Direction West = new("West", new Position(0, -1));
    public string Name { get; private set; }
    public Position Position { get; private set; }

    protected Direction()
    {
    }

    private Direction(string name, Position position)
    {
        Name = name;
        Position = position;
    }

    public Direction Left()
    {
        if (this == North) return West;
        if (this == West) return South;
        if (this == South) return East;
        return North;
    }
    
    public Direction Right()
    {
        if (this == North) return East;
        if (this == East) return South;
        if (this == South) return West;
        return North;
    }

    public static bool operator ==(Direction d1, Direction d2)
        => d1.Position == d2.Position;

    public static bool operator !=(Direction d1, Direction d2)
        => !(d1 == d2);
}