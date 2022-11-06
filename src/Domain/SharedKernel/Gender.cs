using Framework.Results;

namespace Domain.SharedKernel
{
	public class Gender : SeedWork.Enumeration
	{
		#region Constant(s)
		public const int MaxLength = 10;
		#endregion /Constant(s)

		#region Static Member(s)
		public static readonly Gender Male = new(0, Resources.DataDictionary.Male);
		public static readonly Gender Female = new(1, Resources.DataDictionary.Female);

		public static Result<Gender> GetByValue(int? value)
		{
			var result =
				new Result<Gender>();

			if (value is null)
			{
				string errorMessage = string.Format
					(Resources.Messages.Validations.Required, Resources.DataDictionary.Gender);

				result.WithError(errorMessage: errorMessage);

				return result;
			}

			var gender =
				FromValue<Gender>(value: value.Value);

			if (gender is null)
			{
				string errorMessage = string.Format
					(Resources.Messages.Validations.InvalidCode, Resources.DataDictionary.Gender);

				result.WithError(errorMessage: errorMessage);

				return result;
			}

			result.WithValue(gender);

			return result;
		}
		#endregion /Static Member(s)

		private Gender() : base()
		{
		}

		private Gender(int value, string name) : base(value: value, name: name)
		{
		}
	}
}
