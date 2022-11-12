using FluentAssertions;

namespace Framework.DateTime.Test
{
	public class DateTimeTest
	{
		[Fact]
		public void ShouldConvertFromUnixEpochMilliSecondsToDateTime()
		{
			long date = 0000000000000;

			var datetime = date.FromUnixUtcTimeMilliseconds();

		    datetime.Should().Be(new System.DateTime(1970, 01, 01, 0, 0, 0));
		}

		[Fact]
		public void ShouldTrowExcptionWhenDateIsNegetive()
		{
			long time = -0000000010000;

			var datetime = () => time.FromUnixUtcTimeMilliseconds();

			datetime.Should().Throw<ArgumentOutOfRangeException>();
		}
	}
}