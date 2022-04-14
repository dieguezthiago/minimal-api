namespace Api.Models;

public class PlanetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<PlanetAreaDto> Areas { get; set; } = new List<PlanetAreaDto>();

    public class PlanetAreaDto
    {
        public int Id { get; set; }
        public string X { get; set; } = string.Empty;
        public string Y { get; set; } = string.Empty;

        public IEnumerable<AreaRobotDto> Robots { get; set; }

        public class AreaRobotDto
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Position { get; set; } = string.Empty;
        }
    }
}