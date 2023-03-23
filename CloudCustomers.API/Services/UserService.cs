using CloudCustomers.API.Models;
using System.Net;

namespace CloudCustomers.API.Services;

public interface IUserService
{
	Task<List<User>> GetAllUsers();
}

public class UserService : IUserService
{
	private readonly HttpClient _httpClient;
	public UserService(HttpClient httpClient) => _httpClient = httpClient;


	public async Task<List<User>> GetAllUsers()
	{
		var usersResponse = await _httpClient.GetAsync("https://example.com");
		if (usersResponse.StatusCode == HttpStatusCode.NotFound)
		{
			return new List<User>();
		}
		var responseContent = usersResponse.Content;
		var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();

		return allUsers!.ToList();
	}
}

