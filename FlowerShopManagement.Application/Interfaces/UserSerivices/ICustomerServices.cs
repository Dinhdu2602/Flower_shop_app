<<<<<<< HEAD
﻿using FlowerShopManagement.Application.Interfaces.MongoDB;
using FlowerShopManagement.Application.Models;
using FlowerShopManagement.Application.MongoDB.Interfaces;
using FlowerShopManagement.Core.Entities;

namespace FlowerShopManagement.Application.Interfaces.UserSerivices;

public interface ICustomerfService : IUserService
{
    //public Task<List<OrderModel>?> GetOrdersOfUserAsync(string id, IOrderRepository orderRepository);
    public Task<List<OrderDetailModel>?> GetOrdersOfUserAsync(string id, IOrderRepository orderRepository);
    public Task<CartModel?> GetCartOfUserAsync(string id);
    public Task<UserBasicInfoModel> GetUseBasicInfoById(string id);
    public Task<bool> AddItemToCart(string userId, string productId, int amount);
    public Task<bool> UpdateAmountOfItem(string userId, string productId, int amount);
    public Task<bool> UpdateSelection(string userId, string cartItemId, bool isSelected);
    public Task<bool> RemoveItemToCart(string userId, string productId);
    public Task<List<ProductModel>?> GetFavProductsAsync(string id, IAuthService authService, IProductRepository productRepository);
    public Task<bool> AddFavProduct(string userId, string productId, IAuthService authService, IPersonalService personalService);
    public Task<bool> RemoveFavProduct(string userId, string productId, IAuthService authService, IPersonalService personalService);
    public Task<bool> EditInfoAsync(UserBasicInfoModel userModel);
    public Task<bool> EditInfoAsync(UserModel userModel);

}
=======
﻿using FlowerShopManagement.Application.Interfaces.MongoDB;
using FlowerShopManagement.Application.Models;
using FlowerShopManagement.Application.MongoDB.Interfaces;
using FlowerShopManagement.Core.Entities;

namespace FlowerShopManagement.Application.Interfaces.UserSerivices;

public interface ICustomerfService : IUserService
{
    //public Task<List<OrderModel>?> GetOrdersOfUserAsync(string id, IOrderRepository orderRepository);
    public Task<List<OrderDetailModel>?> GetOrdersOfUserAsync(string id, IOrderRepository orderRepository);
    public Task<CartModel?> GetCartOfUserAsync(string id);
    public Task<UserBasicInfoModel> GetUseBasicInfoById(string id);
    public Task<bool> AddItemToCart(string userId, string productId, int amount);
    public Task<bool> UpdateAmountOfItem(string userId, string productId, int amount);
    public Task<bool> UpdateSelection(string userId, string cartItemId, bool isSelected);
    public Task<bool> RemoveItemToCart(string userId, string productId);
    public Task<List<ProductModel>?> GetFavProductsAsync(string id, IAuthService authService, IProductRepository productRepository);
    public Task<bool> AddFavProduct(string userId, string productId, IAuthService authService, IPersonalService personalService);
    public Task<bool> RemoveFavProduct(string userId, string productId, IAuthService authService, IPersonalService personalService);
    public Task<bool> EditInfoAsync(UserBasicInfoModel userModel);
    public Task<bool> EditInfoAsync(UserModel userModel);

}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
