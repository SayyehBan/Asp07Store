﻿namespace Asp07Store.ShopUI.Models;

public class Basket
{
    private List<BasketItem> _items = new();
    public virtual void Add(Product product, int Quantity)
    {
        var basketItem = _items.Where(c => c.Product.Id == product.Id).FirstOrDefault();
        if (basketItem != null)
        {
            basketItem.Quantity += Quantity;
        }
        else
        {
            _items.Add(new BasketItem
            {
                Product = product,
                Quantity = Quantity
            });
        }
    }
    public virtual void Remove(Product product) => _items.RemoveAll(c => c.Product.Id == product.Id);

    public int TotalPrice() => _items.Sum(c => c.Product.Price * c.Quantity);

    public virtual void Clear() => _items.Clear();
    public IEnumerable<BasketItem> Items => _items;
}
