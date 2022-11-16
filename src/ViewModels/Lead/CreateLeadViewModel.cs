namespace ViewModels.Lead;

public class CreateLeadViewModel
{
	public Guid TenentId { get; set; }
	public int? Salutation { get; set; }
	public string? FirstName { get; set; }
	public string LastName { get; set; }
	public string? FullName { get; set; }
	public string Company { get; set; }
	public string? Email { get; set; }
	public string? Title { get; set; }
	public string? Mobile { get; set; }
	public string? Phone { get; set; }
	public int? LeadStatus { get; set; }
	public decimal? AnnualRevenue { get; set; }
	public string? City { get; set; }
	public string? Country { get; set; }
	public string? Description { get; set; }
	public int? Industry { get; set; }
	public int? LeadSource { get; set; }
	public int? NumberOfEmployees { get; set; }
	public string? PostalCode { get; set; }
	public int? Rating { get;  set; }
	public string? State { get;  set; }
	public string? Street { get;  set; }
	public string? Website { get;  set; }

}
