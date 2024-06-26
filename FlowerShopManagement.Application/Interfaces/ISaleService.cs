<<<<<<< HEAD
﻿using FlowerShopManagement.Application.Interfaces.MongoDB;
using FlowerShopManagement.Application.Models;
using FlowerShopManagement.Application.MongoDB.Interfaces;

namespace FlowerShopManagement.Application.Interfaces;

public interface ISaleService
{
    public Task<bool> VerifyOnlineOrder(OrderModel order, IOrderRepository orderRepository, IProductRepository productRepository);
    public Task<OrderModel?> CreateOfflineOrder(OrderModel order, UserModel user, IOrderRepository orderRepository,
        IUserRepository userRepository, IProductRepository productRepository);

    public Task<List<OrderModel>> GetUpdatedOrders(IOrderRepository orderRepository);
    public Task<OrderModel> GetADetailOrder(string id, IOrderRepository orderRepository);

    public void PickItems(List<string> ids, List<int> amounts, List<ProductModel> currentProducts, List<ProductModel> allProductModels);
}
=======
﻿using FlowerShopManagement.Application.Interfaces.MongoDB;
using FlowerShopManagement.Application.Models;
using FlowerShopManagement.Application.MongoDB.Interfaces;

namespace FlowerShopManagement.Application.Interfaces;

public interface ISaleService
{
    public Task<bool> VerifyOnlineOrder(OrderModel order, IOrderRepository orderRepository, IProductRepository productRepository);
    public Task<OrderModel?> CreateOfflineOrder(OrderModel order, UserModel user, IOrderRepository orderRepository,
        IUserRepository userRepository, IProductRepository productRepository);

    public Task<List<OrderModel>> GetUpdatedOrders(IOrderRepository orderRepository);
    public Task<OrderModel> GetADetailOrder(string id, IOrderRepository orderRepository);

    public void PickItems(List<string> ids, List<int> amounts, List<ProductModel> currentProducts, List<ProductModel> allProductModels);
}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
