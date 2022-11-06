using System.Linq;

namespace Domain.SeedWork
{
	/// <summary>
	/// https://github.com/ankitvijay/Enumeration/blob/master/src/Enumeration/Enumeration.cs
	/// </summary>
	public abstract class Enumeration : object, System.IComparable
	{
		#region Static Member(s)
		public static System.Collections.Generic.IEnumerable<T> GetAll<T>() where T : Enumeration
		{
			// **************************************************
			//var result =
			//	typeof(T)
			//	.GetFields(System.Reflection.BindingFlags.Public |
			//		System.Reflection.BindingFlags.Static |
			//		System.Reflection.BindingFlags.DeclaredOnly)
			//		.Select(current => current.GetValue(null))
			//		.Cast<T>();

			//return result;
			// **************************************************

			// **************************************************
			var result1 =
				typeof(T);

			var result2 =
				result1.GetFields
				(System.Reflection.BindingFlags.Public |
				System.Reflection.BindingFlags.Static |
				System.Reflection.BindingFlags.DeclaredOnly)
				;

			var result3 =
				result2
				.Where(current => current.IsLiteral == false)
				.ToList()
				;

			var result4 =
				result3
				.Select(current => current.GetValue(null))
				;

			var result5 =
				result4.Cast<T>()
				;

			return result5;
			// **************************************************
		}

		private static bool TryParse<TEnumeration>
			(System.Func<TEnumeration, bool> predicate, out TEnumeration enumeration) where TEnumeration : Enumeration
		{
			enumeration =
				GetAll<TEnumeration>()
				.FirstOrDefault(predicate);

			return enumeration != null;
		}

		//private static TEnumeration Parse<TEnumeration, TIntOrString>
		//	(TIntOrString nameOrValue, string description, System.Func<TEnumeration, bool> predicate) where TEnumeration : Enumeration
		//{
		//	var matchingItem =
		//		GetAll<TEnumeration>()
		//		.FirstOrDefault(predicate);

		//	//if (matchingItem == null)
		//	//{
		//	//	string errorMessage =
		//	//		$"'{nameOrValue}' is not a valid {description} in {typeof(TEnumeration)}";

		//	//	throw new System.InvalidOperationException(message: errorMessage);
		//	//}

		//	return matchingItem;
		//}

		private static TEnumeration ParseByPredicate<TEnumeration>
			(System.Func<TEnumeration, bool> predicate)
			where TEnumeration : Enumeration
		{
			var matchingItem =
				GetAll<TEnumeration>()
				.FirstOrDefault(predicate);

			return matchingItem;
		}

		/// <summary>
		/// Gets the instance of <typeparamref name="TEnumeration"/> from value or name.
		/// </summary>
		/// <typeparam name="TEnumeration">The type that inherits <see cref="Enumeration"/>.</typeparam>
		/// <param name="valueOrName">The <typeparamref name="TEnumeration"/> value or name.</param>
		/// <param name="enumeration">The <typeparamref name="TEnumeration"/> instance.</param>
		/// <returns>
		/// <c>true</c> if the instance <see cref="Enumeration"/> contains <typeparamref name="TEnumeration"/> with the specified name;
		/// otherwise, <c>false</c>.
		/// </returns>
		public static bool TryGetFromValueOrName<TEnumeration>
			(string valueOrName, out TEnumeration enumeration) where TEnumeration : Enumeration
		{
			return TryParse
				(item => item.Name == valueOrName, out enumeration) ||
				int.TryParse(valueOrName, out var value) &&
				TryParse(item => item.Value == value, out enumeration);
		}

		/// <summary>
		/// Gets the instance of <typeparamref name="TEnumeration"/> from value.
		/// </summary>
		/// <typeparam name="TEnumeration">The type that inherits <see cref="Enumeration"/>.</typeparam>
		/// <returns>The <typeparamref name="TEnumeration"/> instance.</returns>
		/// <exception cref="InvalidOperationException">"<paramref name="value"/> is not valid"</exception> 
		public static TEnumeration
			FromValue<TEnumeration>(int value) where TEnumeration : Enumeration
		{
			//var matchingItem =
			//	Parse<TEnumeration, int>(value, "nameOrValue", item => item.Value == value);

			var matchingItem =
				ParseByPredicate<TEnumeration>(item => item.Value == value);

			return matchingItem;
		}

		///// <summary>
		///// Gets the instance of <typeparamref name="TEnumeration"/> from name.
		///// </summary>
		///// <typeparam name="TEnumeration">The type that inherits <see cref="Enumeration"/>.</typeparam>
		///// <param name="name"></param>
		///// <returns>The <typeparamref name="TEnumeration"/> instance.</returns>
		///// <exception cref="InvalidOperationException">"<paramref name="name"/> is not valid"</exception> 
		//public static TEnumeration FromName<TEnumeration>(string name) where TEnumeration : Enumeration
		//{
		//	var matchingItem =
		//		Parse<TEnumeration, string>(name, "name", item => item.Name == name);

		//	return matchingItem;
		//}
		#endregion /Static Member(s)

		protected Enumeration() : base()
		{
		}

		protected Enumeration(int value, string name) : base()
		{
			Value = value;
			Name = name;
		}

		public int Value { get; }

		public string Name { get; }

		public override string ToString()
		{
			return Name;
		}

		public override bool Equals(object anotherObject)
		{
			if (anotherObject is null)
			{
				return false;
			}

			if (anotherObject is not Enumeration)
			{
				return false;
			}

			if (ReferenceEquals(this, anotherObject))
			{
				return true;
			}

			Enumeration anotherEnumeration = anotherObject as Enumeration;

			// For EF Core!
			if (GetRealType() != anotherEnumeration.GetRealType())
			{
				return false;
			}

			if (GetType() == anotherEnumeration.GetType())
			{
				return Value == anotherEnumeration.Value;
			}

			return false;
		}

		public int CompareTo(object otherObject)
		{
			int result =
				Value.CompareTo((otherObject as Enumeration).Value);

			return result;
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public static bool operator ==(Enumeration left, Enumeration right)
		{
			if (left is null)
			{
				return right is null;
			}

			return left.Equals(right);
		}

		public static bool operator !=(Enumeration left, Enumeration right)
		{
			return !(left == right);
		}

		public static bool operator <(Enumeration left, Enumeration right)
		{
			return left is null ? right is not null : left.CompareTo(right) < 0;
		}

		public static bool operator <=(Enumeration left, Enumeration right)
		{
			return left is null || left.CompareTo(right) <= 0;
		}

		public static bool operator >(Enumeration left, Enumeration right)
		{
			return left is not null && left.CompareTo(right) > 0;
		}

		public static bool operator >=(Enumeration left, Enumeration right)
		{
			return left is null ? right is null : left.CompareTo(right) >= 0;
		}

		/// <summary>
		/// For EF Core!
		/// </summary>
		private System.Type GetRealType()
		{
			System.Type type = GetType();

			if (type.ToString().Contains("Castle.Proxies."))
			{
				return type.BaseType;
			}

			return type;
		}
	}
}
