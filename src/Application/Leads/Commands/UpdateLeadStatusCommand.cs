using Domain.Aggregates.Leads;
using Domain.Aggregates.Leads.ValueObjects;
using Framework.CQRS.Contracts;
using Framework.Results;
using Persistence;
using ViewModels.Lead.ValueObjects;

namespace Application.Leads.Commands;

public class UpdateLeadStatusCommand : ICommandAsync<Lead>
{
	public Guid Id { get; set; }

	public ValueObject LeadStatus { get; set; }

	public Guid? CurrentUserId { get; set; }

}

public class UpdateLeadStatusCommandHandler : ICommandHandlerAsync<UpdateLeadStatusCommand, Lead>
{
	private readonly IUnitOfWork unitOfWork;

	public UpdateLeadStatusCommandHandler(IUnitOfWork unitOfWork)
	{
		this.unitOfWork = unitOfWork;
	}

	public async Task<Lead> HandleAsync(UpdateLeadStatusCommand command)
	{


		var leadModel = await unitOfWork.LeadRepository.GetByIdAsync(command.Id);

		if (leadModel is null)
		{
			return null;
		}

		leadModel.UpdateStatus
		(LeadStatus.GetByValue(command.LeadStatus.Value)
		, command.CurrentUserId.Value);

		await unitOfWork.SaveAsync();

		return leadModel;
	}
}
