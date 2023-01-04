using Application.Leads.MappingConfiguration;
using Domain.Aggregates.Leads.ValueObjects;
using Domain.SharedKernel;
using Framework.CQRS.Contracts;
using Persistence;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using ViewModels.Lead;
using ViewModels.Lead.ValueObjects;

namespace Application.Leads.Commands;

public class CreateLeadCommand : ICommandAsync<Guid>
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

	public Guid? CurrentUserId { get; set; }
}

public sealed class CreateLeadCommandHandler : ICommandHandlerAsync<CreateLeadCommand, Guid>
{
	private readonly IUnitOfWork unitOfWork;

	public CreateLeadCommandHandler(IUnitOfWork unitOfWork)
	{
		this.unitOfWork = unitOfWork;
	}

	public async Task<Guid> HandleAsync(CreateLeadCommand command)
	{
		var createLead =
				Domain.Aggregates.Leads.Lead.Create
				(command.TenantId.Value
				, command.OwnerId.Value
				, Salutation.GetByValue(command.Salutaion.Value)
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
,
				command.Description,
				command.CurrentUserId.Value,
				command.CurrentUserId.Value);

		await unitOfWork.LeadRepository.AddAsync(createLead);

		await unitOfWork.SaveAsync();

		return createLead.Id;
	}
}
