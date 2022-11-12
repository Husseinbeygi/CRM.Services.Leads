using Domain.Aggregates.Leads.ValueObjects;
using Domain.SharedKernel;

namespace Domain.Aggregates.Leads;

public class Lead : SeedWork.AggregateRoot
{
	public Lead(Guid tenantId, Salutation salutation,
		FirstName firstName, LastName lastName, EmailAddress email, LeadStatus status,
		string title, string company, string mobile,
		string phone, Rating rating, string country, string state,
		string city, string street, Industry industry, string annualRevenue,
		LeadSource leadSource, string postalCode, int? numberOfEmployees, string website, string description)
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
		Salutation = salutation;
		CreatedAt = Framework.DateTime.DateTime.GetCurrentUnixUTCTimeMilliseconds();
		#endregion
	}

	#region Property(ies)
	public SharedKernel.FirstName FirstName { get; private set; }
	public SharedKernel.LastName LastName { get; private set; }
	public string Company { get; private set; }
	public SharedKernel.EmailAddress Email { get; private set; }
	public string Title { get; private set; }
	public string Mobile { get; private set; }
	public string Phone { get; private set; }
	public Guid OwnerId { get; private set; }
	public long ModifiedAt { get; private set; }
	public Guid ModifiedById { get; private set; }
	public long CreatedAt { get; private set; }
	public Guid CreatedById { get; private set; }
	public LeadStatus LeadStatus { get; private set; }
	public string AnnualRevenue { get; private set; }
	public string City { get; private set; }
	public string Country { get; private set; }
	public string Description { get; private set; }
	public Industry Industry { get; private set; }
	public LeadSource LeadSource { get; private set; }
	public int? NumberOfEmployees { get; private set; }
	public string PostalCode { get; private set; }
	public Rating Rating { get; private set; }
	public SharedKernel.Salutation Salutation { get; private set; }
	public string State { get; private set; }
	public string Street { get; private set; }
	public string Website { get; private set; }
	public Guid TenantId { get; private set; }

	#endregion /Property(ies)

}
