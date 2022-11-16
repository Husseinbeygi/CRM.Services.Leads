namespace Domain.SharedKernel
{
	public class EmailAddress : SeedWork.ValueObject
	{
		#region Constant(s)
		public const int MaxLength = 250;

		public const int VerificationKeyFixLength = 32;
		#endregion /Constant(s)

		#region Static Member(s)
		public static EmailAddress Create(string value)
		{
			value =
				Text.Fix(value);

			if (value is null)
			{
				return null;
				//string errorMessage = string.Format
				//	(Resources.Messages.Validations.Required,
				//	Resources.DataDictionary.EmailAddress);

				//throw new ArgumentNullOrEmptyException(errorMessage);

			}

			if (value.Length > MaxLength)
			{
				string errorMessage = string.Format
					(Resources.Messages.Validations.MaxLength,
					Resources.DataDictionary.EmailAddress, MaxLength);

				throw new InvalidLengthException(errorMessage);
			}

			try
			{
				var emailAddress =
					new System.Net.Mail.MailAddress(value).Address;
			}
			catch
			{
				string errorMessage = string.Format
					(Resources.Messages.Validations.RegularExpression,
					Resources.DataDictionary.EmailAddress);
				throw new InvalidEmailFormatException(errorMessage);
			}

			var returnValue =
				new EmailAddress(value: value);

			return returnValue;
		}

		public string GetVerificationKey()
		{
			string result =
				System.Guid
				.NewGuid().ToString().Replace("-", string.Empty);

			return result;
		}
		#endregion /Static Member(s)

		private EmailAddress() : base()
		{
		}

		private EmailAddress(string value) : this()
		{
			Value = value;
			IsVerified = false;
			VerificationKey = GetVerificationKey();

		}

		private EmailAddress
			(string value, bool isVerified, string verificationKey) : this(value: value)
		{
			IsVerified = isVerified;
			VerificationKey = verificationKey;
		}

		public string Value { get; }

		public bool IsVerified { get; }

		public string VerificationKey { get; }

		protected override
			IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
			yield return IsVerified;
			yield return VerificationKey;
		}

		public EmailAddress Verify()
		{
			var result =
				new EmailAddress();

			if (IsVerified == true)
			{
				throw new
					EmailAddressAlreadyVerifiedException(result);
			}

			var newObject =
				new EmailAddress
				(value: Value, isVerified: true, verificationKey: VerificationKey);

			return newObject;
		}

		public EmailAddress VerifyByKey(string verificationKey)
		{
			var result =
				new EmailAddress();

			if (string.Compare(VerificationKey, verificationKey, ignoreCase: false) != 0)
			{
				throw new InvalidCodeException
					(Resources.Messages.Errors.InvalidVerificationKey);
			}

			result = Verify();

			return result;
		}

		public override string ToString()
		{
			return Value;
		}
	}
}
