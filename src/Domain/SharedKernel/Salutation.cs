﻿namespace Domain.SharedKernel;

public class Salutation : SeedWork.Enumeration
{
	#region Constant(s)
	public const int MaxLength = 10;
	#endregion /Constant(s)

	#region Static Member(s)
	public static readonly Salutation None = new(0, Resources.DataDictionary.None);
	public static readonly Salutation Mr =   new(1, Resources.DataDictionary.Mr);
	public static readonly Salutation Ms =   new(2, Resources.DataDictionary.Ms);
	public static readonly Salutation Dr =   new(3, Resources.DataDictionary.Doctor);
	public static readonly Salutation Prof = new(4, Resources.DataDictionary.Professor);

	public static Salutation GetByValue(int? value)
	{
		if (value is null)
		{
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Salutation);

			throw new ArgumentNullOrEmptyException(errorMessage);
		}

		var salutation =
			FromValue<Salutation>(value: value.Value);

		if (salutation is null)
		{
			string errorMessage = string.Format
				(Resources.Messages.Validations.InvalidCode, Resources.DataDictionary.Salutation);


			throw new InvalidCodeException(errorMessage);
		}

		return salutation;
	}

	public static List<Salutation> GetAllByCulture()
	{
		/*
			Because the static properties 
			doesn't change the culture 
			dynamically, this was the only way 
			that I can change the value by culture
		*/

		var _salutation = new List<Salutation>() 
		{
			new(0, Resources.DataDictionary.None),
			new(1, Resources.DataDictionary.Mr),
			new(2, Resources.DataDictionary.Ms),
			new(3, Resources.DataDictionary.Doctor),
			new(4, Resources.DataDictionary.Professor),
		};

		return _salutation;
	}
	#endregion /Static Member(s)


	public Salutation()
	{
	}

	public Salutation(int value, string name) : base(value, name)
	{
	}

}