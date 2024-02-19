using Moq;
using StorageService.Application;
using StorageService.Application.Dtos;
using StorageService.Domain.Entities;
using StorageService.Domain.Interfaces;

namespace StorageService.Tests;

public class StorageServiceTestStorageServiceApplication
{
    [Fact]
    public async Task StoreEvent_Calls_AppendEvent_With_Correct_UserInformation()
    {
        // Arrange
        var mockEventRepository = new Mock<IFileEventRepository>();
        var storageServiceApplication = new StorageServiceApplication(mockEventRepository.Object);
        var userInfoDto = new UserInformationDto
        {
            Referrer = "http://example.com",
            UserAgent = "TestAgent",
            IPAddress = "127.0.0.1"
        };

        // Act
        await storageServiceApplication.StoreEvent(userInfoDto);

        // Assert
        mockEventRepository.Verify(repo => repo.AppendEvent(It.Is<UserInformation>(userInfo =>
            userInfo.Referrer == userInfoDto.Referrer &&
            userInfo.UserAgent == userInfoDto.UserAgent &&
            userInfo.IPAddress == userInfoDto.IPAddress
        )), Times.Once);
    }

    [Fact]
    public async Task StoreEvent_Handles_Exception()
    {
        // Arrange
        var mockEventRepository = new Mock<IFileEventRepository>();
        mockEventRepository.Setup(repo => repo.AppendEvent(It.IsAny<UserInformation>())).Throws(new Exception("Test Exception"));
        var storageServiceApplication = new StorageServiceApplication(mockEventRepository.Object);
        var userInfoDto = new UserInformationDto();

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => storageServiceApplication.StoreEvent(userInfoDto));
    }
}