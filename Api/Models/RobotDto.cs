namespace Api.Models;

public class RobotDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Direction { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public RobotAreaDto Area { get; set; } = default!;

    public class RobotAreaDto
    {
        public int Id { get; set; }
        public string X { get; set; } = string.Empty;
        public string Y { get; set; } = string.Empty;
    }
}