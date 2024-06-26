<<<<<<< HEAD
﻿using FlowerShopManagement.Application.Models;
using FlowerShopManagement.Application.MongoDB.Interfaces;
using FlowerShopManagement.Core.Entities;
using FlowerShopManagement.Core.Enums;

namespace FlowerShopManagement.Application.Interfaces.MongoDB;

public interface IOrderRepository : IBaseRepository<Order>
{
    public List<ProfitableProductModel> GetProfitableProducts(DateTime beginDate, DateTime endDate, int limit = 5);
    public List<ValuableCustomerModel> GetValuableCustomers(DateTime beginDate, DateTime endDate, int limit = 5);
    public int GetOrdersCount(DateTime beginDate, DateTime endDate, Status? status = Status.Purchased);
    public List<RevenueModel> GetTotalRevenue(DateTime beginDate, DateTime endDate, string criteria = "$hour", Status status = Status.Purchased);
    public List<TotalOrdersModel> GetTotalOrders(DateTime beginDate, DateTime endDate, string criteria = "$hour", Status status = Status.Purchased);
}
=======
﻿using FlowerShopManagement.Application.Models;
using FlowerShopManagement.Application.MongoDB.Interfaces;
using FlowerShopManagement.Core.Entities;
using FlowerShopManagement.Core.Enums;

namespace FlowerShopManagement.Application.Interfaces.MongoDB;

public interface IOrderRepository : IBaseRepository<Order>
{
    public List<ProfitableProductModel> GetProfitableProducts(DateTime beginDate, DateTime endDate, int limit = 5);
    public List<ValuableCustomerModel> GetValuableCustomers(DateTime beginDate, DateTime endDate, int limit = 5);
    public int GetOrdersCount(DateTime beginDate, DateTime endDate, Status? status = Status.Purchased);
    public List<RevenueModel> GetTotalRevenue(DateTime beginDate, DateTime endDate, string criteria = "$hour", Status status = Status.Purchased);
    public List<TotalOrdersModel> GetTotalOrders(DateTime beginDate, DateTime endDate, string criteria = "$hour", Status status = Status.Purchased);
}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
