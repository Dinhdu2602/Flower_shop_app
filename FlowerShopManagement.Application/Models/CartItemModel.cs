<<<<<<< HEAD
﻿using FlowerShopManagement.Core.Entities;

namespace FlowerShopManagement.Application.Models;

public class CartItemModel
{
    public string _productId { get; set; }
    public string _id { get; private set; }
    public ProductDetailModel items { get; set; }// offline data
    public int amount { get; set; }
    public bool isSelected { get; set; }

    public CartItemModel(string id = "", string pid = "", ProductDetailModel? items = null, int total = 0)
    {
        this._id = id;
        this._productId = pid;
        if (items != null)
            this.items = items;
        else this.items = new ProductDetailModel();
        this.amount = total;
        this.isSelected = false;
    }

    public CartItemModel(CartItem cartItem)
    {
        this._id = cartItem._id;
        this._productId = cartItem._productId;
        if (cartItem.items != null)
            this.items = new ProductDetailModel(cartItem.items);
        else
            this.items = new ProductDetailModel();
        this.amount = cartItem.amount;
        this.isSelected = cartItem.isSelected;
    }

    public CartItemModel(string customerId)
    {
        this._id = Guid.NewGuid().ToString();
        this._productId = "";
        this.items = new ProductDetailModel();
        this.amount = 0;
        this.isSelected = false;
    }

    public CartItemModel()
    {
        this._id = Guid.NewGuid().ToString();
        this._productId = "";
        this.items = new ProductDetailModel();
        this.amount = 0;
        this.isSelected = false;
    }
    public CartItem ToEntity()
    {

        return new CartItem(_id, _productId, items.ToEntity(), amount, isSelected);

    }

}
=======
﻿using FlowerShopManagement.Core.Entities;

namespace FlowerShopManagement.Application.Models;

public class CartItemModel
{
    public string _productId { get; set; }
    public string _id { get; private set; }
    public ProductDetailModel items { get; set; }// offline data
    public int amount { get; set; }
    public bool isSelected { get; set; }

    public CartItemModel(string id = "", string pid = "", ProductDetailModel? items = null, int total = 0)
    {
        this._id = id;
        this._productId = pid;
        if (items != null)
            this.items = items;
        else this.items = new ProductDetailModel();
        this.amount = total;
        this.isSelected = false;
    }

    public CartItemModel(CartItem cartItem)
    {
        this._id = cartItem._id;
        this._productId = cartItem._productId;
        if (cartItem.items != null)
            this.items = new ProductDetailModel(cartItem.items);
        else
            this.items = new ProductDetailModel();
        this.amount = cartItem.amount;
        this.isSelected = cartItem.isSelected;
    }

    public CartItemModel(string customerId)
    {
        this._id = Guid.NewGuid().ToString();
        this._productId = "";
        this.items = new ProductDetailModel();
        this.amount = 0;
        this.isSelected = false;
    }

    public CartItemModel()
    {
        this._id = Guid.NewGuid().ToString();
        this._productId = "";
        this.items = new ProductDetailModel();
        this.amount = 0;
        this.isSelected = false;
    }
    public CartItem ToEntity()
    {

        return new CartItem(_id, _productId, items.ToEntity(), amount, isSelected);

    }

}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
