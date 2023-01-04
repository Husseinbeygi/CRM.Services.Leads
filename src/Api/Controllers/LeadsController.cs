using Api.Helpers;
using Api.MappingConfiguration;
using Application.Leads.Commands;
using Application.Leads.Queries;
using Domain.Aggregates.Leads.ValueObjects;
using Domain.SharedKernel;
using Framework.CQRS;
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
	private readonly ILogger<LeadsController> _logger;

	public LeadsController(
	  CurrentContextHelper contextHelper
	, ILogger<LeadsController> Logger
	, IMessages Messages
	) : base(Messages)
	{
		this.contextHelper = contextHelper;
		_logger = Logger;
	}

	[HttpGet]
	[ProducesResponseType((int)HttpStatusCode.BadRequest)]
	[ProducesResponseType((int)HttpStatusCode.NoContent)]
	[ProducesResponseType(typeof(Result<List<LeadsViewModel>>), (int)HttpStatusCode.OK)]
	public async Task<IActionResult> GetLeads()
	{
		_logger.LogInformation("GET LEADS CALLED!");

		var Result = new Result<List<LeadsViewModel>>();

		try
		{
			var leads = await Messages.DispatchAsync(new GetLeadsQuery());
			if (leads is null)
			{
				return NoContent();
			}

			return Ok(leads.ToResult());

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
		var result = new Result<LeadsViewModel>();

		var lead = await Messages.DispatchAsync(new GetLeadQuery(Id));

		if (lead is null)
		{
			result.AddErrorMessage(string.Format(Resources.Messages.Validations.NotFound,
							Resources.DataDictionary.Lead));
			return NotFound(result);
		}


		result.WithData(lead);

		return Ok(result);

	}


	[HttpPost]
	[ProducesResponseType((int)HttpStatusCode.BadRequest)]
	[ProducesResponseType(typeof(Result<LeadsViewModel>), (int)HttpStatusCode.Created)]
	public async Task<IActionResult> CreateLead(CreateLeadCommand model)
	{
		var tenantId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "buid")?.Value);
		var oid = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);

		var result = new Result<Guid>();
		try
		{

			model.OwnerId = oid;
			model.TenantId = tenantId;
			model.CurrentUserId = contextHelper.CurrentUserId;

			var lead = await Messages.DispatchAsync(model);

			result.WithData(lead);

			return Created($"/Leads/{lead}", result);

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
			var res = await Messages.DispatchAsync(new DeleteLeadCommand(id));

			if (res == false)
			{
				result.AddErrorMessage(string.Format(Resources.Messages.Validations.NotFound,
								Resources.DataDictionary.Lead));
				return NotFound(result);
			}
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
	public async Task<IActionResult> DeleteLeads([FromQuery] List<Guid> ids)
	{
		var result = new Result<ViewModels.Lead.LeadsViewModel>();

		try
		{
			foreach (var id in ids)
			{
				var res = await Messages.DispatchAsync(new DeleteLeadCommand(id));
				if (res == false)
				{
					result.AddErrorMessage(string.Format(Resources.Messages.Validations.NotFound,
									Resources.DataDictionary.Lead));
					return NotFound(result);
				}
			}
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
	public async Task<IActionResult> UpdateLead(UpdateLeadCommand model)
	{

		if (model.TenantId.HasValue == false || model.Id == Guid.Empty)
		{
			return UnprocessableEntity();
		}

		var result = new Result<LeadsViewModel>();

		model.CurrentUserId = contextHelper.CurrentUserId;
		try
		{
			var leadModel = await Messages.DispatchAsync(model);

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
	public async Task<IActionResult> UpdateStatusLead(UpdateLeadStatusCommand model)
	{

		if (model.Id == Guid.Empty)
		{
			return UnprocessableEntity();
		}

		var result = new Result<LeadsViewModel>();

		try
		{
			var lead = await Messages.DispatchAsync(model);

			if (lead is null)
			{
				result.AddErrorMessage(string.Format(Resources.Messages.Validations.NotFound,
								Resources.DataDictionary.Lead));
				return NotFound(result);
			}

			var mappedModel = LeadMapper.Map(lead);

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

