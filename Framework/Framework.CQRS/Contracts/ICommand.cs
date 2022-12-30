using CSharpFunctionalExtensions;

namespace Framework.CQRS.Contracts
{
	public interface ICommand
	{
	}

	public interface ICommandHandler<TCommand>
		where TCommand : ICommand
	{
		Result Handle(TCommand command);
	}


}