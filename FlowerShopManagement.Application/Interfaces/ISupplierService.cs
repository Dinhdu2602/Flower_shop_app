<<<<<<< HEAD
﻿using FlowerShopManagement.Application.Models;

namespace FlowerShopManagement.Application.Interfaces;

public interface ISupplierService
{
    public Task<List<SupplierModel>> GetAllAsync(int skip = 0, int? limit = null);
    public Task<List<SupplierModel>> GetByIdsAsync(List<string> ids);
    public Task<SupplierModel?> GetOneAsync(string id);
    public Task<bool> AddOneAsync(SupplierModel model);
    public Task<bool> UpdateOneAsync(SupplierModel model);
    public Task<bool> RemoveOneAsync(string id); 
}
=======
﻿using FlowerShopManagement.Application.Models;

namespace FlowerShopManagement.Application.Interfaces;

public interface ISupplierService
{
    public Task<List<SupplierModel>> GetAllAsync(int skip = 0, int? limit = null);
    public Task<List<SupplierModel>> GetByIdsAsync(List<string> ids);
    public Task<SupplierModel?> GetOneAsync(string id);
    public Task<bool> AddOneAsync(SupplierModel model);
    public Task<bool> UpdateOneAsync(SupplierModel model);
    public Task<bool> RemoveOneAsync(string id); 
}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
