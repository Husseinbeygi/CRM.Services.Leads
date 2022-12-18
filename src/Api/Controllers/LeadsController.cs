using Api.Helpers;
using Api.MappingConfiguration;
using Domain.Aggregates.Leads.ValueObjects;
using Domain.SharedKernel;
using Framework.Results;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Net;
using System.Security.Claims;
using ViewModels.Lead;
using ViewModels.Lead.ValueObjects;

namespace Api.Controllers;

[Route("api/v1/[controller]")]
[Authorize]
[ApiController]
public class LeadsController : Infrustructure.ControllerBase
{
	private readonly CurrentContextHelper contextHelper;

	public LeadsController(IUnitOfWork unitOfWork,CurrentContextHelper contextHelper) : base(unitOfWork)
	{
		this.contextHelper = contextHelper;
	}

	[HttpGet]
	[ProducesResponseType((int)HttpStatusCode.BadRequest)]
	[ProducesResponseType((int)HttpStatusCode.NoContent)]
	[ProducesResponseType(typeof(Result<List<LeadsViewModel>>), (int)HttpStatusCode.OK)]
	public async Task<IActionResult> GetLeads()
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
	public async Task<IActionResult> GetLead(Guid Id)
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
	[ProducesResponseType(typeof(Result<LeadsViewModel>), (int)HttpStatusCode.Created)]
	public async Task<IActionResult> CreateLead(CreateLeadViewModel model)
	{
		var tenantId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "buid")?.Value);
		var oid = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);

		var result = new Result<ViewModels.Lead.LeadsViewModel>();
		try
		{
			var createLead =
					Domain.Aggregates.Leads.Lead.Create
					(tenantId
					, oid, Salutation.GetByValue(model.Salutaion.Value)
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
,
					model.Description,
					contextHelper.CurrentUserId,
					contextHelper.CurrentUserId);

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


	[HttpDelete]
	[ProducesResponseType((int)HttpStatusCode.BadRequest)]
	[ProducesResponseType((int)HttpStatusCode.OK)]
	public async Task<IActionResult> DeleteLeads([FromQuery]List<Guid> ids)
	{
		var result = new Result<ViewModels.Lead.LeadsViewModel>();

		try
		{
			foreach (var id in ids)
			{
				var res = await UnitOfWork.LeadRepository.RemoveByIdAsync(id);
				if (res == false)
				{
					result.AddErrorMessage(string.Format(Resources.Messages.Validations.NotFound,
									Resources.DataDictionary.Lead));
					return NotFound(result);
				}
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
			, model.VersionNumber
			, contextHelper.CurrentUserId);

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

	[HttpGet("options")]
	[ProducesResponseType((int)HttpStatusCode.BadRequest)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[ProducesResponseType(typeof(Result<LeadsOptions>), (int)HttpStatusCode.OK)]
	public async Task<IActionResult> LeadOptions()
	{
		var result = new Result<LeadsOptions>();
		try
		{
			var leadsOptions = new LeadsOptions()
			{
				Industry = Industry.GetAllByCulture()
				.Adapt<List<ValueObject>>(),

				LeadSource = LeadSource.GetAllByCulture()
				.Adapt<List<ValueObject>>(),

				LeadStatus = LeadStatus.GetAllByCulture()
				.Adapt<List<ValueObject>>(),

				Rating = Rating.GetAllByCulture()
				.Adapt<List<ValueObject>>(),

				Salutation = Salutation.GetAllByCulture()
				.Adapt<List<ValueObject>>(),

			};

			result.WithData(leadsOptions);

			return Ok(result);

		}
		catch (Exception ex)
		{
			result.AddErrorMessage(ex.Message);
			return BadRequest(result);
		}


	}

	[HttpPatch("status")]
	[ProducesResponseType((int)HttpStatusCode.BadRequest)]
	[ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
	[ProducesResponseType(typeof(Result<LeadsViewModel>), (int)HttpStatusCode.Created)]
	public async Task<IActionResult> UpdateStatusLead(UpdateLeadStatusViewModel model)
	{

		if (model.Id == Guid.Empty)
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
			leadModel.UpdateStatus
					(LeadStatus.GetByValue(model.LeadStatus.Value)
					, contextHelper.CurrentUserId);

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

