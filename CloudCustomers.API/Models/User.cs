namespace CloudCustomers.API.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public Address Address { get; set; }

		public User()
		{
			Name = string.Empty;
			Email = string.Empty;
			Address = new();
		}

		public User( string name, string email, Address address)
		{
			Name = name;
			Email = email;
			Address = address;
		}
	}
}
