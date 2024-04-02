using FluentAssertions;
using MobileApp.Application.ShootingEvent;

namespace MobileApp.Application.UnitTest.ShootingEvent;

public class ShootingEventManagerTests
{
    private readonly IShootingEventManager shootingEventManager;

    public ShootingEventManagerTests()
    {
        this.shootingEventManager = new ShootingEventManager();
    }

    [Fact]
    public async Task Get_ShouldReturnOk_IfNoCancellation()
    {
        // Arrange
        IEnumerable<MobileApp.Application.ShootingEvent.ShootingEvent>? response = null;

        // Act
        response = await shootingEventManager.Get(CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        if (response != null)
        {
            response!.Should().NotBeEmpty();
        }
    }

    [Fact]
    public async Task Get_ShouldThrowException_IfCancellation()
    {
        // Arrange
        IEnumerable<MobileApp.Application.ShootingEvent.ShootingEvent>? response = null;
        var tokenSource = new CancellationTokenSource();

        // Act
        tokenSource.Cancel();
        var act = async () => response = await shootingEventManager.Get(tokenSource.Token);

        // Assert
        await act.Should().ThrowAsync<OperationCanceledException>();
    }

    [Theory]
    [InlineData("4fa85f64-5717-4562-b3fc-2c963f66afa6")]
    [InlineData("5fa85f64-5717-4562-b3fc-2c963f66afa6")]
    public async Task GetById_ShouldReturnOk_IfNoCancellationAndIdExists(string eventId)
    {
        // Arrange
        var id = Guid.Parse(eventId);
        MobileApp.Application.ShootingEvent.ShootingEvent? response = null;

        // Act
        response = await shootingEventManager.GetById(id, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
    }

    [Theory]
    [InlineData("fee7c225-8cb3-4050-a9db-85a2e4cf230c")]
    [InlineData("68944c26-b727-4529-a35e-0ba9354592be")]
    public async Task GetById_ShouldReturnOk_IfNoCancellationAndIdNoExists(string eventId)
    {
        // Arrange
        var id = Guid.Parse(eventId);
        MobileApp.Application.ShootingEvent.ShootingEvent? response = null;

        // Act
        response = await shootingEventManager.GetById(id, CancellationToken.None);

        // Assert
        response.Should().BeNull();
    }

    [Fact]
    public async Task GetById_ShouldThrowException_IfCancellation()
    {
        // Arrange
        IEnumerable<MobileApp.Application.ShootingEvent.ShootingEvent>? response = null;
        var tokenSource = new CancellationTokenSource();

        // Act
        tokenSource.Cancel();
        var act = async () => response = await shootingEventManager.Get(tokenSource.Token);

        // Assert
        await act.Should().ThrowAsync<OperationCanceledException>();
    }
}
