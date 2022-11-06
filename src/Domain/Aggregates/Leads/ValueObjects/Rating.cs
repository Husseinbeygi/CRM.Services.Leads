using Domain.SharedKernel;

namespace Domain.Aggregates.Leads.ValueObjects;

public class Rating : SeedWork.Enumeration
{
	#region Constant(s)
	public const int MaxLength = 10;
	#endregion /Constant(s)

	#region Static Member(s)
	public static readonly Rating Cold = new(0, Resources.DataDictionary.Cold);
	public static readonly Rating Warm = new(1, Resources.DataDictionary.Warm);
	public static readonly Rating Hot = new(2, Resources.DataDictionary.Hot);

	public static Rating GetByValue(int? value)
	{
		if (value is null)
		{
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Rating);

			throw new ArgumentNullException(errorMessage);
		}

		var rating =
			FromValue<Rating>(value: value.Value);

		if (rating is null)
		{
			string errorMessage = string.Format
				(Resources.Messages.Validations.InvalidCode, Resources.DataDictionary.Rating);


			throw new InvalidCodeException(errorMessage);
		}

		return rating;
	}
	#endregion /Static Member(s)

	public Rating()
	{
	}

	public Rating(int value, string name) : base(value, name)
	{
	}


}
