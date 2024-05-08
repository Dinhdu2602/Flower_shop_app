<<<<<<< HEAD
﻿namespace FlowerShopManagement.Core.Entities;

public class Supplier
{
    public string _id;

    public string name;
    public string address;
    public string email;
    public string phoneNumber;
    public string description;

    public DateTime createdDate;
    public DateTime lastModified;

    public Supplier()
    {
        _id = Guid.NewGuid().ToString();

        name = string.Empty;
        address = string.Empty;
        email = string.Empty;
        phoneNumber = string.Empty;
        description = string.Empty;

        createdDate = DateTime.Now;
        lastModified = DateTime.Now;
    }
}

public class SupplierBasic
{
    public string _id = string.Empty;
    public string name = string.Empty;
    public string email = string.Empty;
}
=======
﻿namespace FlowerShopManagement.Core.Entities;

public class Supplier
{
    public string _id;

    public string name;
    public string address;
    public string email;
    public string phoneNumber;
    public string description;

    public DateTime createdDate;
    public DateTime lastModified;

    public Supplier()
    {
        _id = Guid.NewGuid().ToString();

        name = string.Empty;
        address = string.Empty;
        email = string.Empty;
        phoneNumber = string.Empty;
        description = string.Empty;

        createdDate = DateTime.Now;
        lastModified = DateTime.Now;
    }
}

public class SupplierBasic
{
    public string _id = string.Empty;
    public string name = string.Empty;
    public string email = string.Empty;
}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
