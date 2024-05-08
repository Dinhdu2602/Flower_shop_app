<<<<<<< HEAD
﻿using FlowerShopManagement.Application.Models;

namespace FlowerShopManagement.Application.Interfaces;

public interface IImportService
{
    public List<ImportModel> GetRequests();

    public Task<ImportModel?> GetRequest(string id);

    public Task<string?> Verify(string id, List<int> deliveredQties, List<string> notes, string userId, string username);

    public Task UpdateStock(string importId);

    public Task<bool> SendRequest(ImportModel form);
    
    public ImportModel CreateRequestForm(
        List<ProductDetailModel> products, 
        SupplierModel suppliers, 
        List<int> reqAmounts, 
        string staffId, string staffName, string htmlPath);
}
=======
﻿using FlowerShopManagement.Application.Models;

namespace FlowerShopManagement.Application.Interfaces;

public interface IImportService
{
    public List<ImportModel> GetRequests();

    public Task<ImportModel?> GetRequest(string id);

    public Task<string?> Verify(string id, List<int> deliveredQties, List<string> notes, string userId, string username);

    public Task UpdateStock(string importId);

    public Task<bool> SendRequest(ImportModel form);
    
    public ImportModel CreateRequestForm(
        List<ProductDetailModel> products, 
        SupplierModel suppliers, 
        List<int> reqAmounts, 
        string staffId, string staffName, string htmlPath);
}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
