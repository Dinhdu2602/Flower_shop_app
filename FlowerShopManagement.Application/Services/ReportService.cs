<<<<<<< HEAD
﻿using FlowerShopManagement.Application.Interfaces;
using FlowerShopManagement.Application.Interfaces.MongoDB;
using FlowerShopManagement.Application.Models;
using FlowerShopManagement.Application.MongoDB.Interfaces;
using FlowerShopManagement.Core.Enums;

namespace FlowerShopManagement.Application.Services;

public class ReportService : IReportService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public ReportService(IProductRepository productRepository, IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public int GetProductsCount(int minimumAmount = 20)
    {
        try
        {
            return _productRepository.GetLowOnStockCount(minimumAmount);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public List<ProfitableProductModel> GetProfitableProducts(DateTime beginDate, DateTime endDate, int limit = 5)
    {
        try
        {
            return _orderRepository.GetProfitableProducts(beginDate, endDate, limit);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public List<ValuableCustomerModel> GetValuableCustomers(DateTime beginDate, DateTime endDate, int limit = 5)
    {
        try
        {
            return _orderRepository.GetValuableCustomers(beginDate, endDate, limit);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public int GetOrdersCount(DateTime beginDate, DateTime endDate, Status status = Status.Purchased)
    {
        try
        {
            // Get total number of orders per date/month/year
            return _orderRepository.GetOrdersCount(beginDate, endDate, status);            
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public List<double?> GetTotalRevenue(DateTime beginDate, DateTime endDate, Status status = Status.Purchased)
    {
        var option = -1;
        var initValue = 0;
        var dataSize = 0;
        var criteria = string.Empty;
        var daysBetween = endDate - beginDate;

        // Daily
        if (daysBetween.Days <= 1)
        {
            dataSize = 24; // total hours per day
            criteria = "$hour"; // group orders by hours
            option = 0;
        }

        // Monthly
        if (daysBetween.Days > 1 && daysBetween.Days <= 31)
        {
            dataSize = DateTime.DaysInMonth(beginDate.Year, beginDate.Month);
            criteria = "$dayOfMonth"; // group orders by days
            option = 1;
        }

        // Yearly
        if (daysBetween.Days > 31)
        {
            dataSize = 12; // total months per year
            criteria = "$month"; // group orders by months
            option = 2;
        }

        try
        {
            // sum up all orders "_total" per date/month/year
            var result = _orderRepository.GetTotalRevenue(beginDate, endDate, criteria, status);

            // generate data set
            var dataSet = Enumerable.Repeat<double?>(initValue, dataSize).ToList();

            foreach (var record in result)
            {
                // local time offset
                if (option == 0)
                {
                    record._id = record._id + 7;
                    if (record._id >= 24)
                        record._id = record._id - 24;
                }

                dataSet[record._id] = record.revenue;
            }

            return dataSet;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public List<double?> GetTotalOrders(DateTime beginDate, DateTime endDate, Status status = Status.Purchased)
    {
        var option = -1;
        var initValue = 0;
        var dataSize = 0;
        var criteria = string.Empty;
        var daysBetween = endDate - beginDate;

        // Daily
        if (daysBetween.Days <= 1)
        {
            dataSize = 24; // total hours per day
            criteria = "$hour"; // group orders by hours
            option = 0;
        }

        // Monthly
        if (daysBetween.Days > 1 && daysBetween.Days <= 31)
        {
            dataSize = DateTime.DaysInMonth(beginDate.Year, beginDate.Month);
            criteria = "$dayOfMonth"; // group orders by days
            option = 1;
        }

        // Yearly
        if (daysBetween.Days > 31)
        {
            dataSize = 12; // total months per year
            criteria = "$month"; // group orders by months
            option = 2;
        }

        try
        {
            // count all orders per date/month/year
            var result = _orderRepository.GetTotalOrders(beginDate, endDate, criteria, status);

            // generate data set
            var dataSet = Enumerable.Repeat<double?>(initValue, dataSize).ToList();

            foreach (var record in result)
            {
                // local time offset
                if (option == 0)
                {
                    record._id = record._id + 7;
                    if (record._id >= 24)
                        record._id = record._id - 24;
                }

                dataSet[record._id] = record.numberOfOrders;
            }

            return dataSet;
        }
        catch (Exception e)
        {
                throw new Exception(e.Message);
        }
    }

    public List<CategoryStatisticModel>? GetCategoryStatistic()
    {
        try
        {
            return _productRepository.GetCategoryStatistic();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
=======
﻿using FlowerShopManagement.Application.Interfaces;
using FlowerShopManagement.Application.Interfaces.MongoDB;
using FlowerShopManagement.Application.Models;
using FlowerShopManagement.Application.MongoDB.Interfaces;
using FlowerShopManagement.Core.Enums;

namespace FlowerShopManagement.Application.Services;

public class ReportService : IReportService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public ReportService(IProductRepository productRepository, IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public int GetProductsCount(int minimumAmount = 20)
    {
        try
        {
            return _productRepository.GetLowOnStockCount(minimumAmount);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public List<ProfitableProductModel> GetProfitableProducts(DateTime beginDate, DateTime endDate, int limit = 5)
    {
        try
        {
            return _orderRepository.GetProfitableProducts(beginDate, endDate, limit);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public List<ValuableCustomerModel> GetValuableCustomers(DateTime beginDate, DateTime endDate, int limit = 5)
    {
        try
        {
            return _orderRepository.GetValuableCustomers(beginDate, endDate, limit);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public int GetOrdersCount(DateTime beginDate, DateTime endDate, Status status = Status.Purchased)
    {
        try
        {
            // Get total number of orders per date/month/year
            return _orderRepository.GetOrdersCount(beginDate, endDate, status);            
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public List<double?> GetTotalRevenue(DateTime beginDate, DateTime endDate, Status status = Status.Purchased)
    {
        var option = -1;
        var initValue = 0;
        var dataSize = 0;
        var criteria = string.Empty;
        var daysBetween = endDate - beginDate;

        // Daily
        if (daysBetween.Days <= 1)
        {
            dataSize = 24; // total hours per day
            criteria = "$hour"; // group orders by hours
            option = 0;
        }

        // Monthly
        if (daysBetween.Days > 1 && daysBetween.Days <= 31)
        {
            dataSize = DateTime.DaysInMonth(beginDate.Year, beginDate.Month);
            criteria = "$dayOfMonth"; // group orders by days
            option = 1;
        }

        // Yearly
        if (daysBetween.Days > 31)
        {
            dataSize = 12; // total months per year
            criteria = "$month"; // group orders by months
            option = 2;
        }

        try
        {
            // sum up all orders "_total" per date/month/year
            var result = _orderRepository.GetTotalRevenue(beginDate, endDate, criteria, status);

            // generate data set
            var dataSet = Enumerable.Repeat<double?>(initValue, dataSize).ToList();

            foreach (var record in result)
            {
                // local time offset
                if (option == 0)
                {
                    record._id = record._id + 7;
                    if (record._id >= 24)
                        record._id = record._id - 24;
                }

                dataSet[record._id] = record.revenue;
            }

            return dataSet;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public List<double?> GetTotalOrders(DateTime beginDate, DateTime endDate, Status status = Status.Purchased)
    {
        var option = -1;
        var initValue = 0;
        var dataSize = 0;
        var criteria = string.Empty;
        var daysBetween = endDate - beginDate;

        // Daily
        if (daysBetween.Days <= 1)
        {
            dataSize = 24; // total hours per day
            criteria = "$hour"; // group orders by hours
            option = 0;
        }

        // Monthly
        if (daysBetween.Days > 1 && daysBetween.Days <= 31)
        {
            dataSize = DateTime.DaysInMonth(beginDate.Year, beginDate.Month);
            criteria = "$dayOfMonth"; // group orders by days
            option = 1;
        }

        // Yearly
        if (daysBetween.Days > 31)
        {
            dataSize = 12; // total months per year
            criteria = "$month"; // group orders by months
            option = 2;
        }

        try
        {
            // count all orders per date/month/year
            var result = _orderRepository.GetTotalOrders(beginDate, endDate, criteria, status);

            // generate data set
            var dataSet = Enumerable.Repeat<double?>(initValue, dataSize).ToList();

            foreach (var record in result)
            {
                // local time offset
                if (option == 0)
                {
                    record._id = record._id + 7;
                    if (record._id >= 24)
                        record._id = record._id - 24;
                }

                dataSet[record._id] = record.numberOfOrders;
            }

            return dataSet;
        }
        catch (Exception e)
        {
                throw new Exception(e.Message);
        }
    }

    public List<CategoryStatisticModel>? GetCategoryStatistic()
    {
        try
        {
            return _productRepository.GetCategoryStatistic();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
}