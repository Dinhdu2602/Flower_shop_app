<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;

namespace FlowerShopManagement.Core.Entities;

public class CartItem
{
    public string _id { get; private set; }
    public string _productId { get; set; }

    public Product items { get; set; }// offline data
    public int amount { get; set; }
    public bool isSelected { get; set; }

    public CartItem(string id = "", string pid = "", Product? items = null, int total = 0, bool isSelected = false)
    {
        this._id = id;
        this._productId = pid;
        if (items != null)
            this.items = items;
        else
            this.items = new Product();
        this.amount = total;
        this.isSelected = false;
    }

    public CartItem(string customerId)
    {
        this._id = Guid.NewGuid().ToString();
        this._productId = "";
        this.items = new Product();
        this.amount = 0;
        this.isSelected = false;
    }
}
=======
﻿using System.ComponentModel.DataAnnotations;

namespace FlowerShopManagement.Core.Entities;

public class CartItem
{
    public string _id { get; private set; }
    public string _productId { get; set; }

    public Product items { get; set; }// offline data
    public int amount { get; set; }
    public bool isSelected { get; set; }

    public CartItem(string id = "", string pid = "", Product? items = null, int total = 0, bool isSelected = false)
    {
        this._id = id;
        this._productId = pid;
        if (items != null)
            this.items = items;
        else
            this.items = new Product();
        this.amount = total;
        this.isSelected = false;
    }

    public CartItem(string customerId)
    {
        this._id = Guid.NewGuid().ToString();
        this._productId = "";
        this.items = new Product();
        this.amount = 0;
        this.isSelected = false;
    }
}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
