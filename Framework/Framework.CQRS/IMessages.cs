using Framework.CQRS.Contracts;

namespace Framework.CQRS
{
	public interface IMessages
	{
		void Dispatch(ICommand command);
		T Dispatch<T>(IQuery<T> query);
		void Publish(INotification domainEvent);
		Task DispatchAsync(ICommand command, CancellationToken cancellationToken);
		Task<T> DispatchAsync<T>(IQuery<T> query, CancellationToken cancellationToken);
		Task PublishAsync(INotification domainEvent, CancellationToken cancellationToken);
	}
}