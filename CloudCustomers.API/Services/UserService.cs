﻿using CloudCustomers.API.Models;

namespace CloudCustomers.API.Services;

public interface IUserService 
{
	Task<List<User>> GetAllUsers();
}

public class UserService : IUserService
{
	public UserService()
	{

	}

	public Task<List<User>> GetAllUsers()
	{
		throw new NotImplementedException();
	}
}

