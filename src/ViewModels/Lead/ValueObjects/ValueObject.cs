using System.Text.Json.Serialization;

namespace ViewModels.Lead.ValueObjects;

public class ValueObject
{
	[JsonConstructor]
	public ValueObject()
	{
	}

	public ValueObject(int key, string value)
	{
		Value = key;
		Name = value;
	}

	public int Value { get; set; }
	public string Name { get; set; }
}
