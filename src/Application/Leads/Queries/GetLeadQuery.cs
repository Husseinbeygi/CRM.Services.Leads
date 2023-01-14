using Application.Leads.MappingConfiguration;
using Cyrus.CQRS.Contracts;
using Persistence;
using ViewModels.Lead;

namespace Application.Leads.Queries;

public class GetLeadQuery : IQueryAsync<LeadsViewModel>
{
	public Guid Id { get; set; }

	public GetLeadQuery(Guid id)	
	{
		Id = id;
	}
}

public sealed class GetLeadQueryHandler : IQueryHandlerAsync<GetLeadQuery, LeadsViewModel>
{
	private readonly IUnitOfWork unitOfWork;

	public GetLeadQueryHandler(IUnitOfWork unitOfWork)
	{
		this.unitOfWork = unitOfWork;
	}

	public  async Task<LeadsViewModel> HandleAsync
		(GetLeadQuery query, CancellationToken cancellationToken = default)
	{
		var leadModel = 
		await unitOfWork.LeadRepository.GetByIdAsync(query.Id);

		var mappedModel = LeadMapper.Map(leadModel);

		return mappedModel;
	}
}
