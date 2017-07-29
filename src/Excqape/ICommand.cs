using System.Threading.Tasks;

namespace Excqape
{
	public interface ICommand<in TCommand> where TCommand : ICommandSpec
	{
		Task<Response> Handle(TCommand command);
	}
}
