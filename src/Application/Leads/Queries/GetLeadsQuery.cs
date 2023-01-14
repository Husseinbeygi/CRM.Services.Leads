using Application.Leads.MappingConfiguration;
using Cyrus.CQRS.Contracts;
using Persistence;
using ViewModels.Lead;

namespace Application.Leads.Queries;

public class GetLeadsQuery : IQueryAsync<List<LeadsViewModel>>
{
	public GetLeadsQuery()
	{

	}

}

public sealed class GetLeadsQueryHandler : IQueryHandlerAsync<GetLeadsQuery, List<LeadsViewModel>>
{
	private readonly IUnitOfWork unitOfWork;

	public GetLeadsQueryHandler(IUnitOfWork unitOfWork)
	{
		this.unitOfWork = unitOfWork;
	}

	public async Task<List<LeadsViewModel>> HandleAsync
		(GetLeadsQuery query, CancellationToken cancellationToken = default)
	{
		var leadModel = await unitOfWork.LeadRepository.GetAllAsync();

		var mappedModel = LeadMapper.Map(leadModel.ToList());

		return mappedModel;
	}
}