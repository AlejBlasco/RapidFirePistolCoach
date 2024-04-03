using Microsoft.AspNetCore.Components;
using MobileApp.Application.ShootingEvent;

namespace MobileApp.Components.Pages;

public partial class EventList
{
    [Inject]
    protected IShootingEventManager shootingEventManager { get; set; } = default!;

    private IEnumerable<ShootingEvent>? eventList { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (shootingEventManager != null)
            eventList = await shootingEventManager.Get();
    }

    
}
