using Domain.Aggregates.Leads;
using Domain.Aggregates.Leads.ValueObjects;
using Domain.SharedKernel;
using Cyrus.CQRS.Contracts;
using Cyrus.Results;
using Persistence;
using ViewModels.Lead;
using ViewModels.Lead.ValueObjects;

namespace Application.Leads.Commands;

public class UpdateLeadCommand : ICommandAsync<Lead>
{
	public decimal? AnnualRevenue { get; set; }
	public string? City { get; set; }
	public string? Company { get; set; }
	public string? Country { get; set; }
	public string? Description { get; set; }
	public string? Email { get; set; }
	public string? FirstName { get; set; }
	public ValueObject Industry { get; set; }
	public string? LastName { get; set; }
	public ValueObject LeadSource { get; set; }
	public ValueObject LeadStatus { get; set; }
	public string? Mobile { get; set; }
	public int? NumberOfEmployees { get; set; }
	public  Guid? OwnerId { get; set; }
	public string? Phone { get; set; }
	public string? PostalCode { get; set; }
	public ValueObject Rating { get; set; }
	public ValueObject Salutaion { get; set; }
	public string? State { get; set; }
	public string? Street { get; set; }
	public  Guid? TenantId { get; set; }
	public string? Title { get; set; }
	public string? Website { get; set; }
	public Guid Id { get; set; }
	public int VersionNumber { get; set; }
	public Guid? CurrentUserId { get; set; }
}

public sealed class UpdateLeadCommandHandler : ICommandHandlerAsync<UpdateLeadCommand, Lead>
{
	private readonly IUnitOfWork unitOfWork;

	public UpdateLeadCommandHandler(IUnitOfWork unitOfWork)
	{
		this.unitOfWork = unitOfWork;
	}

	public async Task<Lead> HandleAsync(UpdateLeadCommand command)
	{
		var leadModel = await unitOfWork.LeadRepository.GetByIdAsync(command.Id);

		if (leadModel is null)
		{
			return null;
		}

		leadModel.Update(
			 Salutation.GetByValue(command.Salutaion.Value)
			, FirstName.Create(command.FirstName)
			, LastName.Create(command.LastName)
			, EmailAddress.Create(command.Email)
			, LeadStatus.GetByValue(command.LeadStatus.Value)
			, command.Title
			, command.Company
			, command.Mobile
			, command.Phone
			, Rating.GetByValue(command.Rating.Value)
			, command.Country
			, command.State
			, command.City
			, command.Street
			, Industry.GetByValue(command.Industry.Value)
			, command.AnnualRevenue
			, LeadSource.GetByValue(command.LeadSource.Value)
			, command.PostalCode
			, command.NumberOfEmployees
			, command.Website
			, command.Description
			, command.VersionNumber
			, command.CurrentUserId.Value);


		await unitOfWork.SaveAsync();

		return leadModel;
	}
}
