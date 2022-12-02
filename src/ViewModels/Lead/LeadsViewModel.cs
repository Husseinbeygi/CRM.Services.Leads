using ViewModels.Lead.ValueObjects;

namespace ViewModels.Lead;

public class LeadsViewModel : LeadsViewModelBase
{
	public Guid Id { get; set; }
	public int VersionNumber { get; set; }

}
