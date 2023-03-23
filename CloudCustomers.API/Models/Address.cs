namespace CloudCustomers.API.Models
{
	public class Address
	{
		public string Street { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		public string ZipCode { get; set; } = string.Empty;

		public Address(string street, string city, string zipCode)
		{
			Street = street;
			City = city;
			ZipCode = zipCode;
		}
		public Address()
		{

		}
	}
}
