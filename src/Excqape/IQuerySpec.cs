namespace Excqape
{
    public interface IQuerySpec
    {
    }

    public interface IQuerySpec<TResult> : IQuerySpec
    {
    }

    public interface IPagedQuerySpec<TResult> : IQuerySpec<PagedResult<TResult>>
    {
        PagingRequest Paging { get; }
    }
}
