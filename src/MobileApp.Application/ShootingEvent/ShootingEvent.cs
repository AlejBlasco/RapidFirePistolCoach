namespace MobileApp.Application.ShootingEvent;

public class ShootingEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string? Name { get; set; }

    public int? SecondsLoading { get; set; }

    public int? SecondsEdge { get; set; }

    public int SecondsFace { get; set; } = 0;

    public int? Times { get; set; }
}
