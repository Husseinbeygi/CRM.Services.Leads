namespace Domain.Aggregates.Leads.ValueObjects;


public class LeadStatus : SeedWork.Enumeration
{

	#region Constant(s)
	public const int MaxLength = 20;
	#endregion /Constant(s)

	#region Static Member(s)
	public static readonly LeadStatus New = new(0, Resources.DataDictionary.New);
	public static readonly LeadStatus Contacted = new(1, Resources.DataDictionary.Contacted);
	public static readonly LeadStatus Working = new(2, Resources.DataDictionary.Working);
	public static readonly LeadStatus Qualified = new(3, Resources.DataDictionary.Qualified);
	public static readonly LeadStatus Unqualified = new(4, Resources.DataDictionary.Unqualified);

	public static LeadStatus GetByValue(int? value)
	{
		if (value is null)
		{
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.LeadStatus);

			throw new ArgumentNullException(errorMessage);
		}

		var leadstatus =
			FromValue<LeadStatus>(value: value.Value);

		if (leadstatus is null)
		{
			string errorMessage = string.Format
				(Resources.Messages.Validations.InvalidCode, Resources.DataDictionary.LeadStatus);


			throw new InvalidCodeException(errorMessage);
		}

		return leadstatus;
	}
	#endregion /Static Member(s)


	public LeadStatus()
	{
	}

	public LeadStatus(int value, string name) : base(value, name)
	{
	}


}

