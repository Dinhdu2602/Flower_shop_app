<<<<<<< HEAD
﻿using FlowerShopManagement.Application.Models;
using FlowerShopManagement.Core.Enums;

namespace FlowerShopManagement.Application.Interfaces;

public interface IAuthService
{
    public Task<UserModel> CreateNewUserAsync(string email, string phoneNb, string password, Role role = Role.Customer);
    public Task<UserModel?> ValidateSignInAsync(string emailOrPhoneNb, string password);
    public Task<UserModel?> GetAuthenticatedUserAsync(string id);
}
=======
﻿using FlowerShopManagement.Application.Models;
using FlowerShopManagement.Core.Enums;

namespace FlowerShopManagement.Application.Interfaces;

public interface IAuthService
{
    public Task<UserModel> CreateNewUserAsync(string email, string phoneNb, string password, Role role = Role.Customer);
    public Task<UserModel?> ValidateSignInAsync(string emailOrPhoneNb, string password);
    public Task<UserModel?> GetAuthenticatedUserAsync(string id);
}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
