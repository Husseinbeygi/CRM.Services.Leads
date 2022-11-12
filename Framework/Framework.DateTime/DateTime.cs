namespace Framework.DateTime;

public static class DateTime 
{

	public static long GetCurrentUnixUTCTimeMilliseconds()
	{
		DateTimeOffset now = DateTimeOffset.UtcNow;
		long unixTimeMilliseconds = now.ToUnixTimeMilliseconds();
		return unixTimeMilliseconds;
	}

	public static long GetCurrentUnixUTCTimeSeconds()
	{
		var now = DateTimeOffset.UtcNow;
		long unixTimeMilliseconds = now.ToUnixTimeSeconds();
		return unixTimeMilliseconds;
	}

	public static System.DateTime FromUnixUtcTimeMilliseconds(this long time)
	{
		if (time < 0)
		{
			throw new ArgumentOutOfRangeException(nameof(time));
		}

		var dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(time);

		return dateTimeOffset.DateTime;
	}

	public static System.DateTime FromUnixUtcTimeSeconds(this long time)
	{
		if (time < 0)
		{
			throw new ArgumentOutOfRangeException(nameof(time));
		}

		var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(time);

		return dateTimeOffset.DateTime;
	}

}