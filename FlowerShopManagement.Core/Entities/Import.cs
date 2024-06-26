<<<<<<< HEAD
﻿using FlowerShopManagement.Core.Enums;

namespace FlowerShopManagement.Core.Entities;

public class Import
{
    public string _id;

    public SupplierBasic supplier;
    public List<ImportItem> details;
    public double total;

    public UserBasic createdBy;
    public UserBasic? checkedBy;

    public ImportStatus status;
    public DateTime createdDate;
    public string note;

    public Import(
        SupplierBasic supplier,
        List<ImportItem> details,
        UserBasic createdBy)
    {
        _id = Guid.NewGuid().ToString();

        this.supplier = supplier;
        this.details = details;
        
        foreach (var item in details)
        {
            total += item.price * item.orderQty;
        }
        
        note = string.Empty;

        this.createdBy = createdBy;
        checkedBy = new UserBasic();

        createdDate = DateTime.Now;
    }
}

public class ImportItem
{
    public string _id = string.Empty;
    public string name = string.Empty;
    public double price = 0.0d;
    public int orderQty = 0;
    public int deliveredQty = 0;
    public string note = string.Empty;
}
=======
﻿using FlowerShopManagement.Core.Enums;

namespace FlowerShopManagement.Core.Entities;

public class Import
{
    public string _id;

    public SupplierBasic supplier;
    public List<ImportItem> details;
    public double total;

    public UserBasic createdBy;
    public UserBasic? checkedBy;

    public ImportStatus status;
    public DateTime createdDate;
    public string note;

    public Import(
        SupplierBasic supplier,
        List<ImportItem> details,
        UserBasic createdBy)
    {
        _id = Guid.NewGuid().ToString();

        this.supplier = supplier;
        this.details = details;
        
        foreach (var item in details)
        {
            total += item.price * item.orderQty;
        }
        
        note = string.Empty;

        this.createdBy = createdBy;
        checkedBy = new UserBasic();

        createdDate = DateTime.Now;
    }
}

public class ImportItem
{
    public string _id = string.Empty;
    public string name = string.Empty;
    public double price = 0.0d;
    public int orderQty = 0;
    public int deliveredQty = 0;
    public string note = string.Empty;
}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
