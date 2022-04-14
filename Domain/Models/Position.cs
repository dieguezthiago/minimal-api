namespace Domain.Models;

public class Position
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static bool operator ==(Position p1, Position p2)
        => p1.X == p2.X && p1.Y == p2.Y;

    public static bool operator !=(Position p1, Position p2)
        => !(p1 == p2);

    public static Position operator +(Position p1, Position p2)
        => new(p1.X + p2.X, p1.Y + p2.Y);

    public override string ToString()
        => $"{X},{Y}";
}