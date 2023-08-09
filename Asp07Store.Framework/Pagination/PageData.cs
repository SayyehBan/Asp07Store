namespace Asp07Store.Framework.Pagination
{
    public class PageData<T>
    {
        public List<T> Data { get; set; }
        public PageInfo pageInfo { get; set; }
    }
}
