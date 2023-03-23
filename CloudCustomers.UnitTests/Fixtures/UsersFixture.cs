using CloudCustomers.API.Models;

namespace CloudCustomers.UnitTests.Fixtures
{
	public static class UsersFixture
	{
		public static List<User> GetTestUsers() 
		{
			var userList = new List<User>();

			userList.Add(new User("TU 1", "testUser1@example.com", new Address("111 Market Str", "City1", "1123")));
			userList.Add(new User("TU 2", "testUser2@example.com", new Address("222 Market Str", "City2", "1223")));
			userList.Add(new User("TU 2", "testUser3@example.com", new Address("333 Market Str", "City3", "1233")));

			return userList;
		}
	}
}
