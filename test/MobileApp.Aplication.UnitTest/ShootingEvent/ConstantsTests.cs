using FluentAssertions;
using System.Text.Json;

namespace MobileApp.Application.UnitTest.ShootingEvent;

public class ConstantsTests
{
    [Fact]
    public void DataJson_ShouldNotBeNullOrWhiteSpace()
    {
        // Arrange

        // Act

        // Assert
        MobileApp.Application.ShootingEvent.Constants.DATA_JSON
            .Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public void DataJson_ShouldNotBeParseable()
    {
        // Arrange
        IEnumerable<MobileApp.Application.ShootingEvent.ShootingEvent>? response = null;
        string dataInput = MobileApp.Application.ShootingEvent.Constants.DATA_JSON;

        // Act
        var act = (() => response = JsonSerializer.Deserialize<IEnumerable<MobileApp.Application.ShootingEvent.ShootingEvent>>(dataInput));

        // Assert
        act.Should().NotThrow<Exception>();

        response.Should().NotBeNull();
        if (response != null)
        {
            response!.Should().NotBeEmpty();
        }
    }
}
