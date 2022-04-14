using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Planet
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Area> Areas { get; set; }

    public Planet(string name)
    {
        Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
        Areas = new List<Area>();
    }

    public void AddArea(int axisXLength, int axisYLength)
    {
        var lastArea = Areas.OrderByDescending(x => x.X.End).FirstOrDefault();

        var initialPosition = new Position(lastArea?.X.End ?? 0, lastArea?.Y.End ?? 0);

        var axisXBegin = initialPosition.X > 0 ? initialPosition.X + 1 : 0;
        var axisXEnd = axisXBegin + axisXLength;

        var axisYBegin = initialPosition.Y > 0 ? initialPosition.Y + 1 : 0;
        var axisYEnd = axisYBegin + axisYLength;

        Areas.Add(new Area(new Axis(axisXBegin, axisXEnd), new Axis(axisYBegin, axisYEnd)));
    }

    public void AssignRobotToArea(int areaId, Robot robot)
        => robot.AssignArea(GetAreaById(areaId));

    public Area GetAreaById(int areaId)
        => Areas.FirstOrDefault(x => x.Id == areaId) ?? throw new ValidationException("Area not found"); //TODO: should represent a NotFound error to be picked by the middleware 
}