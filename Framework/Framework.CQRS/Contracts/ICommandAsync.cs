namespace Framework.CQRS.Contracts
{
	public interface ICommandAsync
	{
	}


	public interface ICommandAsync<T> : ICommandAsync
	{
	}

	public interface ICommandHandlerAsync<TCommand, TResult>
	where TCommand : ICommandAsync
	{
		Task<TResult> HandleAsync(TCommand command);
	}

}