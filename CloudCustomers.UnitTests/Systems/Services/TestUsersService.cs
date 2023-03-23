using CloudCustomers.API.Controllers;
using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using CloudCustomers.UnitTests.Fixtures;
using CloudCustomers.UnitTests.Helpers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Protected;
using Xunit;

namespace CloudCustomers.UnitTests.Systems.Services;

public class TestUsersService
{
	[Fact]
	public async Task GetAllUsers_WhenCalled_InvokeHttpGetRequest() 
	{
		//Arrange
		var expectedResponse = UsersFixture.GetTestUsers();
		var handlerMock = MockHttpMessageHandler<User>.SetupBasicResourceList(expectedResponse);

		var httpClient = new HttpClient(handlerMock.Object);
		var systemUnderTest = new UserService(httpClient);

		//Act
		await systemUnderTest.GetAllUsers();

		//Arrange

		//Verify HTTP request is made
		handlerMock
			.Protected()
			.Verify(
			"SendAsync", 
			Times.Exactly(1), 
			ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
			ItExpr.IsAny<CancellationToken>()
			);
	}

	[Fact]
	public async Task GetAllUsers_WhenHits404_ReturnsEmptyListOfUsers() 
	{
		//Arrange
		var handlerMock = MockHttpMessageHandler<User>.SetupReturn404();

		var httpClient = new HttpClient(handlerMock.Object);
		var systemUnderTest = new UserService(httpClient);

		//Act
		var result = await systemUnderTest.GetAllUsers();

		//Arrange
		result.Count.Should().Be(0);
	}

	[Fact]
	public async Task GetAllUsers_WhenCalled_ReturnsListOfExpectedSize()
	{
		//Arrange
		var expectedResponse = UsersFixture.GetTestUsers();
		var handlerMock = MockHttpMessageHandler<User>.SetupBasicResourceList(expectedResponse);

		var httpClient = new HttpClient(handlerMock.Object);
		var systemUnderTest = new UserService(httpClient);

		//Act
		var result = await systemUnderTest.GetAllUsers();

		//Arrange
		result.Count.Should().Be(expectedResponse.Count);
	}
}

