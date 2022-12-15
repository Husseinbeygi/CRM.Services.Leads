namespace Domain.Aggregates.Leads.ValueObjects;

public class LeadSource : SeedWork.Enumeration
{
	#region Constant(s)
	public const int MaxLength = 20;
	#endregion /Constant(s)

	#region Seeds
	public static readonly LeadSource None = new(0, Resources.DataDictionary.None);
	public static readonly LeadSource Advertisement = new(1, Resources.DataDictionary.Advertisement);
	public static readonly LeadSource ExternalReferral = new(2, Resources.DataDictionary.ExternalReferral);
	public static readonly LeadSource InStore = new(3, Resources.DataDictionary.InStore);
	public static readonly LeadSource OnSite = new(4, Resources.DataDictionary.OnSite);
	public static readonly LeadSource Social = new(5, Resources.DataDictionary.Social);
	public static readonly LeadSource Web = new(6, Resources.DataDictionary.Web);
	public static readonly LeadSource Wordofmouth = new(7, Resources.DataDictionary.Wordofmouth);

	#endregion

	#region Static Member(s)
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

	public static List<LeadSource> GetAllByCulture()
	{
		/*
			Because the static properties 
			doesn't change the culture 
			dynamically, this was the only way 
			that I can change the value by culture
		*/

		var _sources = new List<LeadSource>()
		{
			new(0, Resources.DataDictionary.None),
			new(1, Resources.DataDictionary.Advertisement),
			new(2, Resources.DataDictionary.ExternalReferral),
			new(3, Resources.DataDictionary.InStore),
			new(4, Resources.DataDictionary.OnSite),
			new(5, Resources.DataDictionary.Social),
			new(6, Resources.DataDictionary.Web),
			new(7, Resources.DataDictionary.Wordofmouth),
		};

		return _sources;
	}
	#endregion /Static Member(s)


	public LeadSource()
	{
	}

	public LeadSource(int value, string name) : base(value, name)
	{
	}



}
