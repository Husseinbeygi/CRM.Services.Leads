namespace ViewModels.Lead;

public class LeadsViewModel
{
	public string? FirstName { get; private set; }
	public string? LastName { get; private set; }
	public string? FullName { get; private set; }
	public string? Company { get; private set; }
	public string? Email { get; private set; }
	public string? Title { get; private set; }
	public string? Mobile { get; private set; }
	public string? Phone { get; private set; }
	public string OwnerId { get; private set; }
	public long ModifiedAt { get; private set; }
	public Guid ModifiedById { get; private set; }
	public long CreatedAt { get; private set; }
	public Guid CreatedById { get; private set; }
	public int LeadStatus { get; private set; }
	public decimal? AnnualRevenue { get; private set; }
	public string? City { get; private set; }
	public string? Country { get; private set; }
	public string? Description { get; private set; }
	public string Industry { get; private set; }
	public string LeadSource { get; private set; }
	public int? NumberOfEmployees { get; private set; }
	public string? PostalCode { get; private set; }
	public int Rating { get; private set; }
	public string? State { get; private set; }
	public string? Street { get; private set; }
	public string? Website { get; private set; }
	public Guid TenantId { get; private set; }

}
