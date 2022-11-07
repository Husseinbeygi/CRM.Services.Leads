namespace Framework.DDD
{
	public interface IQueryUnitOfWork : IDisposable
	{
		bool IsDisposed { get; }
	}
}
