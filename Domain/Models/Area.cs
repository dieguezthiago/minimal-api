namespace Domain.Models;

public class Area
{
    public int Id { get; }
    public Axis X { get; protected set; }
    public Axis Y { get; protected set; }

    public int PlanetId { get; }
    public ICollection<Robot> Robots { get; }

    protected Area()
    {
    }

    public Area(Axis x, Axis y)
    {
        X = x;
        Y = y;
        Robots = new List<Robot>();
    }

    public Position GetInitialPosition() => new(X.Begin, Y.Begin);
}