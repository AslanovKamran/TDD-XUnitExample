

using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace CloudCustomers.UnitTests.Helpers
{
	internal static class MockHttpMessageHandler<T>
	{
		internal static Mock<HttpMessageHandler> SetupBasicResourceList(List<T> expectedResponse)
		{
			var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = new StringContent(JsonConvert.SerializeObject(expectedResponse)),
			};
			mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			
			var hadnlerMock = new Mock<HttpMessageHandler>();
			hadnlerMock.Protected().Setup<Task<HttpResponseMessage>>(
				"SendAsync",
				ItExpr.IsAny<HttpRequestMessage>(),
				ItExpr.IsAny<CancellationToken>())
				.ReturnsAsync(mockResponse);

			return hadnlerMock;
		}

		internal static Mock<HttpMessageHandler> SetupReturn404() 
		{
			var mockResponse = new HttpResponseMessage(HttpStatusCode.NotFound)
			{
				Content = new StringContent("")
			};
			mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var hadnlerMock = new Mock<HttpMessageHandler>();
			hadnlerMock.Protected().Setup<Task<HttpResponseMessage>>(
				"SendAsync",
				ItExpr.IsAny<HttpRequestMessage>(),
				ItExpr.IsAny<CancellationToken>())
				.ReturnsAsync(mockResponse);

			return hadnlerMock;

		}
	}
}
