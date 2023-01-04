using Framework.CQRS.Contracts;
using Persistence;

namespace Application.Leads.Commands;

public class DeleteLeadCommand : ICommandAsync<bool>
{
	public Guid Id { get; }

	public DeleteLeadCommand(Guid id)
	{
		Id = id;
	}
}


public class DeleteLeadCommandHandler : ICommandHandlerAsync<DeleteLeadCommand,bool>
{
	private readonly IUnitOfWork unitOfWork;

	public DeleteLeadCommandHandler(IUnitOfWork unitOfWork)
	{
		this.unitOfWork = unitOfWork;
	}

	public async Task<bool> HandleAsync(DeleteLeadCommand command)
	{

		var res = await unitOfWork.LeadRepository.RemoveByIdAsync(command.Id);

		unitOfWork.SaveAsync();

		return res;	
	}
}
