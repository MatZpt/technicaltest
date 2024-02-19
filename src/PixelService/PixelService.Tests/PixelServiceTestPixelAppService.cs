using Microsoft.AspNetCore.Http;
using Moq;
using PixelService.Application;
using PixelService.Domain.Entities;
using PixelService.Domain.Interfaces;

namespace PixelService.Tests;

public class PixelServiceTestPixelAppService
{
    [Fact]
    public async Task GetPixelAsync_Returns_TransparentPixel()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var mockStorageService = new Mock<IStorageService>();
        var instance = new PixelAppService(mockStorageService.Object);

        // Act
        var result = await instance.GetPixelAsync(context);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7", Convert.ToBase64String(result));

        // Verify that StoreUserInformationAsync was called
        mockStorageService.Verify(mock => mock.StoreUserInformationAsync(It.IsAny<UserInformation>()), Times.Once);
    }

}