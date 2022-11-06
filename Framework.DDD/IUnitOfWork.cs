namespace Framework.DDD
{
	public interface IUnitOfWork : IDisposable
	{
		bool IsDisposed { get; }

		Task<int> SaveAsync();
	}
}
