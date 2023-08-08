namespace Asp07Store.ShopUI.Models;

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
public class SessionBasket : Basket
{

    private ISession _session;
    public static SessionBasket GetBasket(IServiceProvider service)
    {
        var session = service.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
        SessionBasket basket = session.GetJson<SessionBasket>(DefaultValue.sessionKey) ?? new SessionBasket();
        basket._session = session;
        return basket;
    }
    public override void Add(Product product, int Quantity)
    {
        base.Add(product, Quantity);
        _session.SetJson(DefaultValue.sessionKey, this);
    }
    public override void Remove(Product product)
    {
        base.Remove(product);
        _session.SetJson(DefaultValue.sessionKey, this);
    }
    public override void Clear()
    {
        base.Clear();
        _session.Remove(DefaultValue.sessionKey);
    }
}

public class BasketItem
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}