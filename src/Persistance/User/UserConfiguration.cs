using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.User;

public class UserConfiguration : 
		IEntityTypeConfiguration<Domain.Aggregates.Users.User>
{
	public void Configure
			(EntityTypeBuilder<Domain.Aggregates.Users.User> builder)
	{
		builder.ToTable("Users");

		builder.Property(x => x.Id)
		.ValueGeneratedNever();

		builder.Property(x => x.Fname)
			.IsRequired()
			.HasMaxLength(255);

		builder.Property(x => x.Lname)
		 .IsRequired()
		 .HasMaxLength(255);

	}
}
