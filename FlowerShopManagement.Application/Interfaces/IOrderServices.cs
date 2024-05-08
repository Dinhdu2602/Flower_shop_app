<<<<<<< HEAD
﻿using FlowerShopManagement.Application.Interfaces.MongoDB;
using FlowerShopManagement.Application.MongoDB.Interfaces;
using FlowerShopManagement.Application.Models;

namespace FlowerShopManagement.Application.Interfaces;

public interface IOrderServices
{
    public Task<bool> CreateOrder(OrderModel order, UserModel currentUser, IOrderRepository orderRepository, IUserRepository userRepository, IProductRepository productRepository);
}
=======
﻿using FlowerShopManagement.Application.Interfaces.MongoDB;
using FlowerShopManagement.Application.MongoDB.Interfaces;
using FlowerShopManagement.Application.Models;

namespace FlowerShopManagement.Application.Interfaces;

public interface IOrderServices
{
    public Task<bool> CreateOrder(OrderModel order, UserModel currentUser, IOrderRepository orderRepository, IUserRepository userRepository, IProductRepository productRepository);
}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
