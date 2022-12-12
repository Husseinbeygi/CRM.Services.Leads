using ViewModels.Lead.ValueObjects;

namespace ViewModels.Lead;

public class LeadsOptions
{
	public List<ValueObject> LeadSource { get; set; }
	public List<ValueObject> LeadStatus { get; set; }
	public List<ValueObject> Industry { get; set; }
	public List<ValueObject> Rating { get; set; }
	public List<ValueObject> Salutation { get; set; }

}