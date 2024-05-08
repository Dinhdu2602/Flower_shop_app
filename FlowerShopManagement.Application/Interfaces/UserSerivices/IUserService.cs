<<<<<<< HEAD
﻿using FlowerShopManagement.Application.Models;
using FlowerShopManagement.Core.Entities;

namespace FlowerShopManagement.Application.Interfaces.UserSerivices;

public interface IUserService
{
    public Task<bool> ResetPasswordAsync(UserModel userModel);
    public Task<bool> RemoveAccountAsync(string userId, string userRole);


}
=======
﻿using FlowerShopManagement.Application.Models;
using FlowerShopManagement.Core.Entities;

namespace FlowerShopManagement.Application.Interfaces.UserSerivices;

public interface IUserService
{
    public Task<bool> ResetPasswordAsync(UserModel userModel);
    public Task<bool> RemoveAccountAsync(string userId, string userRole);


}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
