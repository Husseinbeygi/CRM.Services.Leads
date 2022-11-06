namespace Domain.Aggregates.Leads.ValueObjects;

public class LeadSource : SeedWork.Enumeration
{
	#region Constant(s)
	public const int MaxLength = 20;
	#endregion /Constant(s)

	#region Static Member(s)
	public static readonly LeadSource Advertisement = new(0, Resources.DataDictionary.Advertisement);
	public static readonly LeadSource ExternalReferral = new (1, Resources.DataDictionary.ExternalReferral);
	public static readonly LeadSource InStore = new (2, Resources.DataDictionary.InStore);
	public static readonly LeadSource OnSite = new (3, Resources.DataDictionary.OnSite);
	public static readonly LeadSource Social = new(4, Resources.DataDictionary.Social);
	public static readonly LeadSource Web = new(5, Resources.DataDictionary.Web);
	public static readonly LeadSource Wordofmouth = new(6, Resources.DataDictionary.Wordofmouth);

	public static LeadSource GetByValue(int? value)
	{
		if (value is null)
		{
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.LeadSource);

			throw new ArgumentNullException(errorMessage);
		}

		var leadsource =
			FromValue<LeadSource>(value: value.Value);

		if (leadsource is null)
		{
			string errorMessage = string.Format
				(Resources.Messages.Validations.InvalidCode, Resources.DataDictionary.LeadSource);


			throw new InvalidCodeException(errorMessage);
		}

		return leadsource;
	}
	#endregion /Static Member(s)


	public LeadSource()
	{
	}

	public LeadSource(int value, string name) : base(value, name)
	{
	}



}
