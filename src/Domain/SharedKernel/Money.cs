namespace Domain.SharedKernel
{
	public abstract class Money : SeedWork.ValueObject
	{
		#region Constant(s)
		public const int Minimum = 0;

		public const int Maximum = 10_000_000;
		#endregion /Constant(s)

		#region Static Member(s)
		public static FluentResults.Result<Money> Create(int value)
		{
			var result =
				new FluentResults.Result<Money>();

			if ((value < Minimum) || (value > Maximum))
			{
				string errorMessage = string.Format
					(Resources.Messages.Validations.Range, Resources.DataDictionary.Money, Minimum, Maximum);

				result.WithError(errorMessage: errorMessage);

				return result;
			}

			//var returnValue =
			//	new Money(value: value);

			//result.WithValue(value: returnValue);

			return result;
		}

		public static FluentResults.Result<Money> operator +(Money left, Money right)
		{
			int value =
				left.Value + right.Value;

			var result =
				Create(value: value);

			return result;
		}

		public static FluentResults.Result<Money> operator -(Money left, Money right)
		{
			int value =
				left.Value - right.Value;

			var result =
				Create(value: value);

			return result;
		}
		#endregion /Static Member(s)

		private Money() : base()
		{
		}

		protected Money(int value) : this()
		{
			Value = value;
		}

		public int Value { get; }

		protected override
			System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}
