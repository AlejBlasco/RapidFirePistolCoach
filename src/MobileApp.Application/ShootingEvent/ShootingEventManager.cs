using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace MobileApp.Application.ShootingEvent;

public class ShootingEventManager : IShootingEventManager
{
    private readonly IEnumerable<ShootingEvent>? shootingEvents;

    public ShootingEventManager()
    {
        this.shootingEvents = JsonSerializer.Deserialize<IEnumerable<ShootingEvent>>(Constants.DATA_JSON);
        if (this.shootingEvents == null)
            throw new ArgumentNullException(nameof(this.shootingEvents));
    }

    public async Task<IEnumerable<ShootingEvent>?> Get() => await Get(CancellationToken.None);

    public async Task<IEnumerable<ShootingEvent>?> Get(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        IEnumerable<ShootingEvent>? response = null;

        await Task.Run(() =>
        {
            response = this.shootingEvents;
        }, cancellationToken);

        return response;
    }

    public async Task<ShootingEvent?> GetById(Guid eventId) => await GetById(eventId, CancellationToken.None);

    public async Task<ShootingEvent?> GetById(Guid eventId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        ShootingEvent? response = null;

        await Task.Run(() =>
        {
            if (shootingEvents != null && shootingEvents.Any())
                response = shootingEvents.FirstOrDefault(x => x.Id == eventId);
        }, cancellationToken);

        return response;
    }
}
