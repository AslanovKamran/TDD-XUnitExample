using CloudCustomers.API.Controllers;
using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CloudCustomers.UnitTests.Systems.Controllers;


public class UnitTest1
{
	[Fact]
	public async Task Get_OnSuccess_ReturnsStatusCode200()
	{
		//Arrange
		var mockUserService = new Mock<IUserService>();
		mockUserService.Setup(service => service.GetAllUsers())
						.ReturnsAsync(new List<User>()
						{
							new()
							{  Id=1,
								Name = "John",
								Address = new ()
								{
									Street = "17 Main Str.",
									City = "Madison",
									ZipCode = "123"
								},
								Email = "johnDoe228@example.com"

							}
						});

		var systemUnderTest = new UsersController(mockUserService.Object);


		//Act
		var result = (OkObjectResult)await systemUnderTest.Get();

		//Assert
		result.StatusCode.Should().Be(200);
	}

	[Fact]
	public async Task Get_OnSuccess_InvokeUserServiceOnce()
	{
		//Arrange
		var mockUserService = new Mock<IUserService>();
		mockUserService.Setup(service => service.GetAllUsers())
						.ReturnsAsync(new List<User>());

		var systemUnderTest = new UsersController(mockUserService.Object);

		//Act
		var result = await systemUnderTest.Get();
		//Assert
		mockUserService.Verify(service => service.GetAllUsers(), Times.Once);
	}

	[Fact]
	public async Task Get_OnSuccess_ReturnsListOfUsers()
	{
		//Arrange
		var mockUserService = new Mock<IUserService>();
		mockUserService.Setup(service => service.GetAllUsers())
						.ReturnsAsync(new List<User>()
						{
							new()
							{  Id=1,
								Name = "John",
								Address = new ()
								{
									Street = "17 Main Str.",
									City = "Madison",
									ZipCode = "123"
								},
								Email = "johnDoe228@example.com"
								
							}
						});

		var systemUnderTest = new UsersController(mockUserService.Object);

		//Act
		var result = await systemUnderTest.Get();

		//Assert
		result.Should().BeOfType<OkObjectResult>();
		var objResult = (OkObjectResult)result;
		objResult.Value.Should().BeOfType<List<User>>();
	}

	[Fact]
	public async Task Get_OnNoUsersFound_Returns404()
	{
		//Arrange
		var mockUserService = new Mock<IUserService>();
		mockUserService.Setup(service => service.GetAllUsers())
						.ReturnsAsync(new List<User>());

		var systemUnderTest = new UsersController(mockUserService.Object);

		//Act
		var result = await systemUnderTest.Get();

		//Assert
		result.Should().BeOfType<NotFoundResult>();
		var objectResult = (NotFoundResult)result;
		objectResult.StatusCode.Should().Be(404);
	}



}