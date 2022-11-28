using Api.MappingConfiguration;
using Domain.Aggregates.Leads.ValueObjects;
using Domain.SharedKernel;
using Framework.Results;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Net;
using ViewModels.Lead;

namespace Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class LeadsController : Infrustructure.ControllerBase
{

	public LeadsController(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	[HttpGet]
	[ProducesResponseType((int)HttpStatusCode.BadRequest)]
	[ProducesResponseType((int)HttpStatusCode.NoContent)]
	[ProducesResponseType(typeof(Result<List<LeadsViewModel>>), (int)HttpStatusCode.OK)]
	public async Task <IActionResult> GetLeads()
	{
		var Result = new Framework.Results.Result<List<LeadsViewModel>>();

		try
		{
			var leadModel = (await UnitOfWork.LeadRepository.GetAllAsync()).ToList();
			if (leadModel is null)
			{
				return NoContent();
			}
			var mappedModel = LeadMapper.Map(leadModel);

			//Result.WithData(mappedModel);

			return Ok(mappedModel.ToResult());

		}
		catch (Exception ex)
		{
			Result.AddErrorMessage(ex.Message);
			return BadRequest(Result);
		}

	}


	[HttpGet("{Id}")]
	[ProducesResponseType((int)HttpStatusCode.BadRequest)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[ProducesResponseType(typeof(Result<LeadsViewModel>), (int)HttpStatusCode.OK)]
	public async Task<IActionResult>GetLead(Guid Id)
	{
		var result = new Result<ViewModels.Lead.LeadsViewModel>();

		var leadModel = await UnitOfWork.LeadRepository.GetByIdAsync(Id);
		if (leadModel is null)
		{
			result.AddErrorMessage(string.Format(Resources.Messages.Validations.NotFound,
							Resources.DataDictionary.Lead));
			return NotFound(result);
		}

		var mappedModel = LeadMapper.Map(leadModel);

		result.WithData(mappedModel);

		return Ok(result);

	}


	[HttpPost]
	[ProducesResponseType((int)HttpStatusCode.BadRequest)]
	[ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
	[ProducesResponseType(typeof(Result<LeadsViewModel>), (int)HttpStatusCode.Created)]
	public async Task<IActionResult> CreateLead(CreateLeadViewModel model)
	{

		if (model.TenantId.HasValue == false)
		{
			return UnprocessableEntity();
		}

		var result = new Result<ViewModels.Lead.LeadsViewModel>();
		try
		{
			var createLead = new
					Domain.Aggregates.Leads.Lead
					(model.TenantId.Value
					, Salutation.GetByValue(model.Salutaion.Value)
					, FirstName.Create(model.FirstName)
					, LastName.Create(model.LastName)
					, EmailAddress.Create(model.Email)
					, LeadStatus.GetByValue(model.LeadStatus.Value)
					, model.Title
					, model.Company
					, model.Mobile
					, model.Phone
					, Rating.GetByValue(model.Rating.Value)
					, model.Country
					, model.State
					, model.City
					, model.Street
					, Industry.GetByValue(model.Industry.Value)
					, model.AnnualRevenue
					, LeadSource.GetByValue(model.LeadSource.Value)
					, model.PostalCode
					, model.NumberOfEmployees
					, model.Website
					, model.Description);

			await UnitOfWork.LeadRepository.AddAsync(createLead);

			await UnitOfWork.SaveAsync();

			var mappedModel = LeadMapper.Map(createLead);

			result.WithData(mappedModel);

			return Created($"/Leads/{mappedModel.Id}", result);

		}
		catch (Exception ex)
		{
			result.AddErrorMessage(ex.Message);
			return BadRequest(result);
		}


	}


	[HttpDelete("{id}")]
	[ProducesResponseType((int)HttpStatusCode.BadRequest)]
	[ProducesResponseType((int)HttpStatusCode.OK)] 
	public async Task<IActionResult> DeleteLead(Guid id)
	{
		var result = new Result<ViewModels.Lead.LeadsViewModel>();

		try
		{
			var res = await UnitOfWork.LeadRepository.RemoveByIdAsync(id);
			if (res == false)
			{
				result.AddErrorMessage(string.Format(Resources.Messages.Validations.NotFound,
								Resources.DataDictionary.Lead));
				return NotFound(result);
			}
			await UnitOfWork.SaveAsync();
			return Ok();
		}
		catch (Exception ex)
		{
			result.AddErrorMessage(ex.Message);
			return BadRequest(result);
		}
	}


	[HttpPatch]
	[ProducesResponseType((int)HttpStatusCode.BadRequest)]
	[ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
	[ProducesResponseType(typeof(Result<LeadsViewModel>), (int)HttpStatusCode.Created)]
	public async Task<IActionResult> UpdateLead(UpdateLeadViewModel model)
	{

		if (model.TenantId.HasValue == false || model.Id == Guid.Empty)
		{
			return UnprocessableEntity();
		}

		var result = new Result<LeadsViewModel>();

		var leadModel = await UnitOfWork.LeadRepository.GetByIdAsync(model.Id);

		if (leadModel is null)
		{
			result.AddErrorMessage(string.Format(Resources.Messages.Validations.NotFound,
							Resources.DataDictionary.Lead));
			return NotFound(result);
		}

		try
		{
			leadModel.Update(
			 Salutation.GetByValue(model.Salutaion.Value)
			, FirstName.Create(model.FirstName)
			, LastName.Create(model.LastName)
			, EmailAddress.Create(model.Email)
			, LeadStatus.GetByValue(model.LeadStatus.Value)
			, model.Title
			, model.Company
			, model.Mobile
			, model.Phone
			, Rating.GetByValue(model.Rating.Value)
			, model.Country
			, model.State
			, model.City
			, model.Street
			, Industry.GetByValue(model.Industry.Value)
			, model.AnnualRevenue
			, LeadSource.GetByValue(model.LeadSource.Value)
			, model.PostalCode
			, model.NumberOfEmployees
			, model.Website
			, model.Description
			);

			await UnitOfWork.SaveAsync();

			var mappedModel = LeadMapper.Map(leadModel);

			result.WithData(mappedModel);

			return Ok(result);
		}
		catch (Exception ex)
		{
			result.AddErrorMessage(ex.Message);
			return BadRequest(result);
		}

	}

}
