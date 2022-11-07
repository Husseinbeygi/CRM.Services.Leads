using Domain.SharedKernel.Exceptions;

namespace Domain.SharedKernel
{
	public class FirstName : SeedWork.ValueObject
	{
		#region Constant(s)
		public const int MaxLength = 50;
		#endregion /Constant(s)

		#region Static Member(s)
		public static FirstName Create(string value)
		{
			value =
				Framework.Strings.Text.Fix(text: value);

			if (value is null)
			{
				string errorMessage = string.Format
					(Resources.Messages.Validations.Required, Resources.DataDictionary.FirstName);

				throw new ArgumentNullException(errorMessage);
			}

			if (value.Length > MaxLength)
			{
				string errorMessage = string.Format
					(Resources.Messages.Validations.MaxLength,
					Resources.DataDictionary.FirstName, MaxLength);

				throw new InvalidLengthException(errorMessage);
			}

			var returnValue =
				new FirstName(value: value);

			return returnValue;
		}
		#endregion /Static Member(s)

		private FirstName() : base()
		{
		}

		private FirstName(string value) : this()
		{
			Value = value;
		}

		public string Value { get; }

		protected override
			IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}

		public override string ToString()
		{
			if (string.IsNullOrWhiteSpace(Value))
			{
				return "-----";
			}
			else
			{
				return Value;
			}
		}
	}
}
