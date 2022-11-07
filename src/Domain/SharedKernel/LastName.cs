using Domain.SharedKernel.Exceptions;

namespace Domain.SharedKernel
{
	public class LastName : SeedWork.ValueObject
	{
		#region Constant(s)
		public const int MaxLength = 50;
		#endregion /Constant(s)

		#region Static Member(s)
		public static LastName Create(string value)
		{

			value =
				Framework.Strings.Text.Fix(text: value);

			if (value is null)
			{
				string errorMessage = string.Format
					(Resources.Messages.Validations.Required, Resources.DataDictionary.LastName);

				throw new ArgumentNullException(errorMessage);

			}

			if (value.Length > MaxLength)
			{
				string errorMessage = string.Format
					(Resources.Messages.Validations.MaxLength,
					Resources.DataDictionary.LastName, MaxLength);

				throw new InvalidLengthException(errorMessage);
			}

			var returnValue =
				new LastName(value: value);

			return returnValue;
		}
		#endregion /Static Member(s)

		private LastName() : base()
		{
		}

		private LastName(string value) : this()
		{
			Value = value;
		}

		public string Value { get; }

		protected override
			System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
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
