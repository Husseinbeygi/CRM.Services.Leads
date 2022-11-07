namespace Domain.SharedKernel
{
	public class MobilePhone : SeedWork.ValueObject
	{
		#region Constant(s)
		public const int FixLength = 11;

		public const int VerificationKeyFixLength = 6;
		#endregion /Constant(s)

		#region Static Member(s)
		public static MobilePhone Create(string value)
		{
			var result =
				new MobilePhone();

			value =
				Text.Fix(text: value);

			if (value is null)
			{
				string errorMessage = string.Format
					(Resources.Messages.Validations.Required, Resources.DataDictionary.Mobile);

				throw new ArgumentNullOrEmptyException(errorMessage);
			}

			if (value.Length != FixLength)
			{
				string errorMessage = string.Format
					(Resources.Messages.Validations.FixLengthNumeric,
					Resources.DataDictionary.Mobile, FixLength);

				throw new InvalidLengthException(errorMessage);	
			}

			var returnValue =
				new MobilePhone(value: value);


			return returnValue;
		}

		public string GetVerificationKey()
		{
			string result =
				System.Guid.NewGuid()
				.ToString().Replace("-", string.Empty)
				.Substring(startIndex: 0, length: VerificationKeyFixLength);

			return result;
		}
		#endregion /Static Member(s)

		private MobilePhone() : base()
		{
		}

		private MobilePhone(string value) : this()
		{
			Value = value;
			IsVerified = false;
			VerificationKey = GetVerificationKey();

		}

		private MobilePhone
			(string value, bool isVerified, string verificationKey) : this(value: value)
		{
			IsVerified = isVerified;
			VerificationKey = verificationKey;
		}

		public string Value { get; }

		public bool IsVerified { get; }

		public string VerificationKey { get; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
			yield return IsVerified;
			yield return VerificationKey;
		}

		public MobilePhone Verify()
		{
			if (IsVerified == true)
			{
				throw new MobilePhoneAlreadyVerifiedException();
			}

			var newObject =
				new MobilePhone
				(value: Value, isVerified: true, verificationKey: VerificationKey);


			return newObject;
		}

		public MobilePhone VerifyByKey(string verificationKey)
		{
			if (string.Compare(VerificationKey, verificationKey, ignoreCase: false) != 0)
			{
				throw new InvalidCodeException
					(Resources.Messages.Errors.InvalidVerificationKey);
			}

			return Verify();
		}

		public override string ToString()
		{
			return Value;
		}
	}
}
