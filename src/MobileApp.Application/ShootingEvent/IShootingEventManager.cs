﻿namespace MobileApp.Application.ShootingEvent;

public interface IShootingEventManager
{
    Task<IEnumerable<ShootingEvent>?> Get(CancellationToken cancellationToken);

    Task<ShootingEvent?> GetById(Guid eventId, CancellationToken cancellationToken);

}
