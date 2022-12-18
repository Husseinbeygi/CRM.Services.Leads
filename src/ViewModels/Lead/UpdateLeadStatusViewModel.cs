using ViewModels.Lead.ValueObjects;

namespace ViewModels.Lead;

public class UpdateLeadStatusViewModel
{
	public Guid Id { get; set; }
	public ValueObject LeadStatus { get; set; }
}
