using System.Threading.Tasks;

namespace Excqape
{
	public interface IQuery<in TQuery, TResult> where TQuery : IQuerySpec<TResult>
	{
		Task<Response<TResult>> Handle(TQuery query);
	}
}
