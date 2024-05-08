<<<<<<< HEAD
﻿using FlowerShopManagement.Application.MongoDB.Interfaces;
using FlowerShopManagement.Core.Entities;
using FlowerShopManagement.Core.Enums;

namespace FlowerShopManagement.Application.Interfaces.MongoDB;

public interface IImportRepository : IBaseRepository<Import> 
{
    public List<Import> GetRequests(ImportStatus? status = null ,int skip = 0, int? limit = null);
}
=======
﻿using FlowerShopManagement.Application.MongoDB.Interfaces;
using FlowerShopManagement.Core.Entities;
using FlowerShopManagement.Core.Enums;

namespace FlowerShopManagement.Application.Interfaces.MongoDB;

public interface IImportRepository : IBaseRepository<Import> 
{
    public List<Import> GetRequests(ImportStatus? status = null ,int skip = 0, int? limit = null);
}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
