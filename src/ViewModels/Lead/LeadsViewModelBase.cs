using ViewModels.Lead.ValueObjects;

namespace ViewModels.Lead
{
	public class LeadsViewModelBase
	{
		public long Code { get; set; }
		public decimal? AnnualRevenue { get; set; }
		public string? City { get; set; }
		public string? Company { get; set; }
		public string? Country { get; set; }
		public DateTime? CreatedAt { get; set; }
		public Guid? CreatedById { get; set; }
		public string? CreatedBy { get; set; }
		public string? Description { get; set; }
		public string? Email { get; set; }
		public string? FirstName { get; set; }
		public string? FullName { get; set; }
		public ValueObject Industry { get; set; }
		public string? LastName { get; set; }
		public ValueObject LeadSource { get; set; }
		public ValueObject LeadStatus { get; set; }
		public string? Mobile { get; set; }
		public DateTime? ModifiedAt { get; set; }
		public Guid? ModifiedById { get; set; }
		public string? ModifiedBy { get; set; }
		public int? NumberOfEmployees { get; set; }
		public Guid? OwnerId { get; set; }
		public string? Owner { get; set; }
		public string? Phone { get; set; }
		public string? PostalCode { get; set; }
		public ValueObject Rating { get; set; }
		public ValueObject Salutaion { get; set; }
		public string? State { get; set; }
		public string? Street { get; set; }
		public Guid? TenantId { get; set; }
		public string? Title { get; set; }
		public string? Website { get; set; }
	}
}