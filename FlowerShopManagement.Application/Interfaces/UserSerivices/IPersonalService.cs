<<<<<<< HEAD
﻿using FlowerShopManagement.Application.Models;

namespace FlowerShopManagement.Application.Interfaces.UserSerivices;

public interface IPersonalService : IUserService
{
    public Task<bool> EditInfoAsync(UserModel userModel);
    public Task<bool> ChangePasswordAsync(UserModel user, string newPassword);
}
=======
﻿using FlowerShopManagement.Application.Models;

namespace FlowerShopManagement.Application.Interfaces.UserSerivices;

public interface IPersonalService : IUserService
{
    public Task<bool> EditInfoAsync(UserModel userModel);
    public Task<bool> ChangePasswordAsync(UserModel user, string newPassword);
}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
