	namespace Domain.Aggregates.Leads.ValueObjects;

public class Industry : SeedWork.Enumeration
{
	#region Constant(s)
	public const int MaxLength = 50;
	#endregion /Constant(s)

	#region Seeds
	public static readonly Industry None = new(0, Resources.DataDictionary.None);
	public static readonly Industry Agriculture = new(31, Resources.DataDictionary.Agriculture);
	public static readonly Industry Apparel = new(1, Resources.DataDictionary.Apparel);
	public static readonly Industry Banking = new(2, Resources.DataDictionary.Banking);
	public static readonly Industry Biotechnology = new(3, Resources.DataDictionary.Biotechnology);
	public static readonly Industry Chemicals = new(4, Resources.DataDictionary.Chemicals);
	public static readonly Industry Communications = new(5, Resources.DataDictionary.Communications);
	public static readonly Industry Construction = new(6, Resources.DataDictionary.Construction);
	public static readonly Industry Consulting = new(7, Resources.DataDictionary.Consulting);
	public static readonly Industry Education = new(8, Resources.DataDictionary.Education);
	public static readonly Industry Electronics = new(9, Resources.DataDictionary.Electronics);
	public static readonly Industry Energy = new(10, Resources.DataDictionary.Energy);
	public static readonly Industry Engineering = new(11, Resources.DataDictionary.Engineering);
	public static readonly Industry Entertainment = new(12, Resources.DataDictionary.Entertainment);
	public static readonly Industry Environmental = new(13, Resources.DataDictionary.Environmental);
	public static readonly Industry Finance = new(14, Resources.DataDictionary.Finance);
	public static readonly Industry Government = new(15, Resources.DataDictionary.Government);
	public static readonly Industry Healthcare = new(16, Resources.DataDictionary.Healthcare);
	public static readonly Industry Hospitality = new(17, Resources.DataDictionary.Hospitality);
	public static readonly Industry Insurance = new(18, Resources.DataDictionary.Insurance);
	public static readonly Industry Machinery = new(19, Resources.DataDictionary.Machinery);
	public static readonly Industry Manufacturing = new(29, Resources.DataDictionary.Manufacturing);
	public static readonly Industry Media = new(20, Resources.DataDictionary.Media);
	public static readonly Industry NotForProfit = new(21, Resources.DataDictionary.NotForProfit);
	public static readonly Industry Retail = new(22, Resources.DataDictionary.Retail);
	public static readonly Industry Shipping = new(23, Resources.DataDictionary.Shipping);
	public static readonly Industry Technology = new(24, Resources.DataDictionary.Technology);
	public static readonly Industry Telecommunications = new(25, Resources.DataDictionary.Telecommunications);
	public static readonly Industry Transportation = new(26, Resources.DataDictionary.Transportation);
	public static readonly Industry Utilities = new(27, Resources.DataDictionary.Utilities);
	public static readonly Industry Recreation = new(28, Resources.DataDictionary.Recreation);
	public static readonly Industry Other = new(30, Resources.DataDictionary.Other);
	#endregion /Seeds

	#region Static Member(s)
	public static Industry GetByValue(int? value)
	{
		if (value is null)
		{
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Indstry);

			throw new ArgumentNullException(errorMessage);
		}

		var industry =
			FromValue<Industry>(value: value.Value);

		if (industry is null)
		{
			string errorMessage = string.Format
				(Resources.Messages.Validations.InvalidCode, Resources.DataDictionary.Indstry);


			throw new InvalidCodeException(errorMessage);
		}

		return industry;
	}
	#endregion /Static Member(s)

	public Industry()
	{

	}

	public Industry(int value, string name) : base(value, name)
	{
	}
}
