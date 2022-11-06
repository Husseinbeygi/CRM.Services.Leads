namespace Domain.SharedKernel
{
	public abstract class Date : SeedWork.ValueObject
	{
		#region Static Member(s)
		public static bool operator <(Date left, Date right)
		{
			return left.Value < right.Value;
		}

		public static bool operator <=(Date left, Date right)
		{
			return left.Value <= right.Value;
		}

		public static bool operator >(Date left, Date right)
		{
			return left.Value > right.Value;
		}

		public static bool operator >=(Date left, Date right)
		{
			return left.Value >= right.Value;
		}
		#endregion /Static Member(s)

		/// <summary>
		/// For EF Core!
		/// باشد protected نکته: باید
		/// </summary>
		protected Date() : base()
		{
		}

		/// <summary>
		/// باشد protected نکته: باید
		/// </summary>
		protected Date(System.DateTime? value) : this()
		{
			if (value is not null)
			{
				value =
					value.Value.Date;
			}

			Value = value;
		}

		public System.DateTime? Value { get; }

		protected override
			System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}

		public override string ToString()
		{
			if (Value is null)
			{
				return "-----";
			}

			string result =
				Value.Value.ToString("yyyy/MM/dd");

			return result;
		}
	}
}
