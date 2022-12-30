using Framework.CQRS.Contracts;

namespace Framework.CQRS
{
	public interface IMessages
	{
		void Dispatch(ICommand command);
		T Dispatch<T>(IQuery<T> query);
		void Publish(INotification domainEvent);
		Task DispatchAsync(ICommandAsync command, CancellationToken cancellationToken = default);
		Task<T> DispatchAsync<T>(ICommandAsync<T> command, CancellationToken cancellationToken = default);
		Task<T> DispatchAsync<T>(IQueryAsync<T> query, CancellationToken cancellationToken = default);
		Task PublishAsync(INotification domainEvent, CancellationToken cancellationToken = default);
	}
}