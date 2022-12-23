using Domain.Aggregates.Leads.ValueObjects;
using Domain.Aggregates.Users;
using Domain.Exceptions;
using Domain.SharedKernel;

namespace Domain.Aggregates.Leads;

public class Lead : SeedWork.AggregateRoot
{
	protected Lead()
	{

	}
	private Lead(Guid tenantId, Guid ownerid,
		Salutation salutation, FirstName firstName, LastName lastName, EmailAddress email,
		LeadStatus status, string title, string company,
		string mobile, string phone, Rating rating, string country,
		string state, string city, string street, Industry industry,
		decimal? annualRevenue, LeadSource leadSource, string postalCode,
		int? numberOfEmployees, string website, string description,
		Guid createdById, Guid modifiedById)
	{


		LastName = lastName ?? throw new ArgumentNullOrEmptyException
			(string.Format(Resources.Messages.Validations.Required, Resources.DataDictionary.LastName));

		Company = company ?? throw new ArgumentNullOrEmptyException
			(string.Format(Resources.Messages.Validations.Required, Resources.DataDictionary.CompanyName));

		#region AssignTheFields
		FirstName = firstName;
		Email = email;
		Title = title;
		Mobile = mobile;
		Phone = phone;
		LeadStatus = status;
		AnnualRevenue = annualRevenue;
		City = city;
		Country = country;
		Description = description;
		Industry = industry;
		LeadSource = leadSource;
		NumberOfEmployees = numberOfEmployees;
		PostalCode = postalCode;
		Rating = rating;
		State = state;
		Street = street;
		Website = website;
		TenantId = tenantId;
		OwnerId = ownerid;
		CreatedById = createdById;
		ModifiedById = modifiedById;
		CreatedAt = Framework.DateTime.DateTime
					.GetCurrentUnixUTCTimeMilliseconds();
		SetModifiedAt();
		#endregion

		//IncreaseVersion();
	}

	public static Lead Create(Guid tenantId, Guid ownerid,
		Salutation salutation, FirstName firstName, LastName lastName, EmailAddress email,
		LeadStatus status, string title, string company,
		string mobile, string phone, Rating rating, string country,
		string state, string city, string street, Industry industry,
		decimal? annualRevenue, LeadSource leadSource, string postalCode,
		int? numberOfEmployees, string website, string description, Guid createdById, Guid modifiedById)
	{
		var _lead = new Lead(tenantId, ownerid, salutation, firstName, lastName,
			email, status, title, company, mobile, phone, rating, country, state,
			city, street, industry, annualRevenue, leadSource, postalCode,
			numberOfEmployees, website, description, createdById, modifiedById);

		return _lead;
	}

	public void Update(Salutation salutation, FirstName firstName, LastName lastName, EmailAddress email,
		LeadStatus leadStatus, string? title, string company, string? mobile, string? phone, Rating rating,
		string? country, string? state, string? city, string? street, Industry industry, decimal? annualRevenue,
		LeadSource leadSource, string? postalCode, int? numberOfEmployees, string? website, string? description,
		int version, Guid modifiedById)
	{
		LastName = lastName ?? throw new ArgumentNullOrEmptyException
			(string.Format(Resources.Messages.Validations.Required, Resources.DataDictionary.LastName));

		Company = company ?? throw new ArgumentNullOrEmptyException
			(string.Format(Resources.Messages.Validations.Required, Resources.DataDictionary.CompanyName));

		if (version < VersionNumber)
		{
			throw new OptimisticConcurrencyException();
		}

		#region AssignTheFields
		FirstName = firstName;
		Email = email;
		Title = title;
		Mobile = mobile;
		Phone = phone;
		LeadStatus = leadStatus;
		AnnualRevenue = annualRevenue;
		City = city;
		Country = country;
		Description = description;
		Industry = industry;
		LeadSource = leadSource;
		NumberOfEmployees = numberOfEmployees;
		PostalCode = postalCode;
		Rating = rating;
		State = state;
		Street = street;
		Website = website;
		ModifiedById = modifiedById;
		#endregion

		SetModifiedAt();
		//IncreaseVersion();
	}

	private void SetModifiedAt()
	{
		ModifiedAt =
		Framework.DateTime.DateTime
		.GetCurrentUnixUTCTimeMilliseconds();
	}

	public void UpdateStatus(LeadStatus status, Guid modifiedById)
	{

		LeadStatus = status;

		ModifiedById = modifiedById;

		SetModifiedAt();

		//IncreaseVersion();
	}

	#region Property(ies)
	public long Code { get; set; }
	public SharedKernel.FirstName FirstName { get; private set; }
	public SharedKernel.LastName LastName { get; private set; }
	public virtual SharedKernel.Salutation Salutation { get; private set; }
	public string Company { get; private set; }
	public SharedKernel.EmailAddress Email { get; private set; }
	public string? Title { get; private set; }
	public string? Mobile { get; private set; }
	public string? Phone { get; private set; }
	public Guid OwnerId { get; private set; }
	public virtual User Owner { get; private set; }
	public long ModifiedAt { get; private set; }
	public Guid ModifiedById { get; private set; }
	public virtual User ModifiedBy { get; private set; }
	public long CreatedAt { get; private set; }
	public Guid CreatedById { get; private set; }
	public virtual User CreatedBy { get; private set; }
	public virtual LeadStatus LeadStatus { get; private set; }
	public decimal? AnnualRevenue { get; private set; }
	public string? City { get; private set; }
	public string? Country { get; private set; }
	public string? Description { get; private set; }
	public virtual Industry Industry { get; private set; }
	public virtual LeadSource LeadSource { get; private set; }
	public int? NumberOfEmployees { get; private set; }
	public string? PostalCode { get; private set; }
	public virtual Rating Rating { get; private set; }
	public string? State { get; private set; }
	public string? Street { get; private set; }
	public string? Website { get; private set; }
	public Guid TenantId { get; private set; }

	#endregion /Property(ies)

}
