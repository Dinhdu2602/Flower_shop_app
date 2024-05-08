<<<<<<< HEAD
﻿using FlowerShopManagement.Application.Models;
using FlowerShopManagement.Application.MongoDB.Interfaces;
using FlowerShopManagement.Core.Enums;

namespace FlowerShopManagement.Application.Interfaces.UserSerivices;

public interface IAdminService : IStaffService
{
    public Task<bool> AddStaffAsync(UserModel newStaffModel, Role role);
    public Task<bool> EditUserRoleAsync(UserModel userModel, Role role);
    public Task<bool> EditUserAsync(UserModel userModel);
    public Task<List<AddressModel>> GetAddresses();
    public Task<List<string>> FindWards(string city, string district);
    public Task<List<string>> FindDistricts(string city);
}
=======
﻿using FlowerShopManagement.Application.Models;
using FlowerShopManagement.Application.MongoDB.Interfaces;
using FlowerShopManagement.Core.Enums;

namespace FlowerShopManagement.Application.Interfaces.UserSerivices;

public interface IAdminService : IStaffService
{
    public Task<bool> AddStaffAsync(UserModel newStaffModel, Role role);
    public Task<bool> EditUserRoleAsync(UserModel userModel, Role role);
    public Task<bool> EditUserAsync(UserModel userModel);
    public Task<List<AddressModel>> GetAddresses();
    public Task<List<string>> FindWards(string city, string district);
    public Task<List<string>> FindDistricts(string city);
}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
