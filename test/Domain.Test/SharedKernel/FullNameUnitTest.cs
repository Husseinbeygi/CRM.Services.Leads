namespace Domain.Test.SharedKernel
{
	public class FullNameUnitTest : object
	{
		public FullNameUnitTest() : base()
		{
		}
		[Theory]
		[InlineData(null, null, null)]
		[InlineData(10, null, null)]
		[InlineData(1, "Ali Reza", null)]
		[InlineData(1, null, null)]
		public void ShouldThrowErrorWhenInputDataIsNullOrEmpty(int? salutation, string firstName, string lastName)
		{
			var result = () =>
			Domain.SharedKernel.FullName.Create
			(salutation: null, firstName: null, lastName: null);


			result.Should().Throw<ArgumentNullOrEmptyException>();
		}



		[Xunit.Fact]
		public void ShouldCreateFullNameWhenInputIsvalid()
		{
			var result =
				Domain.SharedKernel.FullName.Create
				(salutation: Domain.SharedKernel.Salutation.Mr.Value,
				firstName: "  Ali     Reza  ", lastName: "  Alavi     Asl  ");



			result.FirstName.Value.Should().Be("Ali Reza");
			result.LastName.Value.Should().Be("Alavi Asl");
			result.Salutation.Value.Should().Be(1);
		}
	}
}
