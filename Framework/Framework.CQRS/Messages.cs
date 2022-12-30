using Framework.CQRS.Contracts;

namespace Framework.CQRS
{
	public sealed class Messages : IMessages
	{
		private readonly IServiceProvider _provider;

		public Messages(IServiceProvider provider, CancellationToken cancellationToken)
		{
			_provider = provider;
		}

		public void Dispatch(ICommand command)
		{
			Type type = typeof(ICommandHandler<>);
			Type[] typeArgs = { command.GetType() };
			Type handlerType = type.MakeGenericType(typeArgs);

			dynamic handler = _provider.GetService(handlerType);
			handler.Handle((dynamic)command);
		}

		public T Dispatch<T>(IQuery<T> query)
		{
			Type type = typeof(IQueryHandler<,>);
			Type[] typeArgs = { query.GetType(), typeof(T) };
			Type handlerType = type.MakeGenericType(typeArgs);

			dynamic handler = _provider.GetService(handlerType);
			T result = handler.Handle((dynamic)query);

			return result;
		}

		public Task DispatchAsync(ICommand command,
		CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<T> DispatchAsync<T>(IQuery<T> query,
		CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public void Publish(INotification domainEvent)
		{
			throw new NotImplementedException();
		}

		public Task PublishAsync(INotification domainEvent,
		CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
