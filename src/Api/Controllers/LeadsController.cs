using AutoMapper;
using Domain.Aggregates.Leads.ValueObjects;
using Domain.SharedKernel;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using ViewModels.Lead;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeadsController : Infrustructure.ControllerBase
{
	private readonly IMapper mapper;

	public LeadsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
	{
		this.mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> GetLeads()
	{
		//var Result = new Framework.Results.Result<List<Domain.Aggregates.Leads.Lead>>();

		var leadModel = await UnitOfWork.LeadRepository.GetAllAsync();

		//var mappedModel = mapper.Map<ViewModels.Lead.LeadsViewModel>(leadModel);	

		return Ok(leadModel);
	}

	[HttpPost]
	public async Task<IActionResult> CreateLead(CreateLeadViewModel model)
	{
		try
		{
var createLead = new
		Domain.Aggregates.Leads.Lead
		(model.TenentId
		, Salutation.GetByValue(model.Salutation)
		, FirstName.Create(model.FirstName)
		, LastName.Create(model.LastName)
		, EmailAddress.Create(model.Email)
		, LeadStatus.GetByValue(model.LeadStatus)
		, model.Title
		, model.Company
		, model.Mobile
		, model.Phone
		, Rating.GetByValue(model.Rating)
		, model.Country
		, model.State
		, model.City
		, model.Street
		, Industry.GetByValue(model.Industry)
		, model.AnnualRevenue
		, LeadSource.GetByValue(model.LeadSource)
		, model.PostalCode
		, model.NumberOfEmployees
		, model.Website
		, model.Description);

			await UnitOfWork.LeadRepository.AddAsync(createLead);

			await UnitOfWork.SaveAsync();

			return Created("http://test.com",createLead);

		}
		catch (Exception ex)
		{

			return BadRequest(ex.Message);
		}

	}

	//[HttpGet]
	//public async Task<IActionResult> GetLead(Guid Id)
	//{

	//}

	//[HttpDelete]
	//public async Task<IActionResult> DeleteLead(Guid Id)
	//{

	//}

	//[HttpPatch]
	//public async Task<IActionResult> UpdateLead(Guid Id)
	//{

	//}

}
