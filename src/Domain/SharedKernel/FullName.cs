namespace Domain.SharedKernel
{
	public class FullName : SeedWork.ValueObject
	{

		#region Static Member(s)
		public static FluentResults.Result<FullName>
			Create(int? salutation, string firstName, string lastName)
		{
			var result =
				new Result<FullName>();

			try
			{
				var salutationResult =
					Salutation.GetByValue(value: salutation);

				var firstNameResult =
					FirstName.Create(value: firstName);

				var lastNameResult =
					LastName.Create(value: lastName);

				var returnValue =
					new FullName(salutation: salutationResult,
					firstName: firstNameResult, lastName: lastNameResult);

				result.WithValue(value: returnValue);

			}
			catch (Exception ex)
			{

				result.WithError(ex.Message);
			}

			return result;

		}
		#endregion /Static Member(s)

		private FullName() : base()
		{
		}

		private FullName
			(Salutation salutation, FirstName firstName, LastName lastName) : this()
		{
			Salutation = salutation;
			LastName = lastName;
			FirstName = firstName;
		}

		public LastName LastName { get; }

		public FirstName FirstName { get; }

		public Salutation Salutation { get; }

		protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
		{
			yield return Salutation;
			yield return FirstName;
			yield return LastName;
		}

		public override string ToString()
		{
			string result =
				$"{Salutation?.Name} {FirstName?.Value} {LastName?.Value}".Trim();

			return result;
		}
	}
}
