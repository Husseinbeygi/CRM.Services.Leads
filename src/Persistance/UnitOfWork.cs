using Persistence.Lead;

namespace Persistence;

public class UnitOfWork : Framework.EntityFrameworkCore.UnitOfWork<DatabaseContext>, IUnitOfWork
{
	private readonly DatabaseContext databaseContext;

	public UnitOfWork(DatabaseContext databaseContext) : base(databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	private LeadRepository _leadRepo;
	public ILeadRepository LeadRepository
	{
		get
		{
			if (_leadRepo is null)
			{
				_leadRepo = new LeadRepository(databaseContext);
			}
			return _leadRepo;
		}
	}
}