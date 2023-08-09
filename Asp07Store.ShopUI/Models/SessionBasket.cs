namespace Asp07Store.ShopUI.Models
{
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
}
