using System.ComponentModel.DataAnnotations;
using static Domain.Models.Direction;

namespace Domain.Models;

public class Robot
{
    public int Id { get; }
    public string Name { get; private set; }
    public Direction Direction { get; private set; }
    public Position Position { get; private set; } = default!;

    public int AreaId { get; }
    public Area Area { get; private set; } = default!;

    public Robot(string name)
    {
        Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
    }

    public void AssignArea(Area area)
    {
        Direction = North;
        Position = area.GetInitialPosition();
        Area = area;
    }

    public void TurnRight()
    {
        CheckAreaAssignment();
        Direction = Direction.Right();
    }

    public void TurnLeft()
    {
        CheckAreaAssignment();
        Direction = Direction.Left();
    }

    public void MoveForward()
    {
        CheckAreaAssignment();
        if (Direction == North && Position.X < Area.X.End
            || Direction == East && Position.Y < Area.Y.End
            || Direction == South && Position.X > Area.X.Begin
            || Direction == West && Position.Y > Area.Y.Begin)
        {
            Position += Direction.Position;
        }
        else
        {
            throw new ValidationException($"Robot has reached the Area limit for the current direction! ({Direction.Name})");
        }
    }

    private void CheckAreaAssignment()
    {
        if (Area is null)
            throw new ValidationException("Robot not assigned to a Planet/Area!");
    }
}