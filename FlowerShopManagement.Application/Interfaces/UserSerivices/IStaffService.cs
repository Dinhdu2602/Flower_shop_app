<<<<<<< HEAD
﻿using FlowerShopManagement.Application.Models;

namespace FlowerShopManagement.Application.Interfaces.UserSerivices;

public interface IStaffService : IUserService
{
    public Task<List<UserModel>?> GetUsersAsync();
    public Task<List<UserModel1>?> GetUsersAsync1();
    public Task<UserModel?> GetUserByPhone(string phoneNb);
    public Task<bool> AddCustomerAsync(UserModel newCustomerModel);
    public Task<bool> RemoveUserAsync(UserModel userModel);


}
=======
﻿using FlowerShopManagement.Application.Models;

namespace FlowerShopManagement.Application.Interfaces.UserSerivices;

public interface IStaffService : IUserService
{
    public Task<List<UserModel>?> GetUsersAsync();
    public Task<List<UserModel1>?> GetUsersAsync1();
    public Task<UserModel?> GetUserByPhone(string phoneNb);
    public Task<bool> AddCustomerAsync(UserModel newCustomerModel);
    public Task<bool> RemoveUserAsync(UserModel userModel);


}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
