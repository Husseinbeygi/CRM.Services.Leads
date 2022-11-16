using Domain.SharedKernel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.SharedKernel;

public class SalutationConfiguration : IEntityTypeConfiguration<Salutation>
{
	public void Configure(EntityTypeBuilder<Salutation> builder)
	{
		builder
			.ToTable(name: "Salutations");

		builder
			.HasKey(p => p.Value);

		builder
			.Property(p => p.Value)
			.ValueGeneratedNever()
			.IsRequired(required: true);

		builder
			.Property(p => p.Name)
			.IsRequired(required: true)
			.HasMaxLength(maxLength: Salutation.MaxLength);

		builder.HasData(Salutation.None);
		builder.HasData(Salutation.Mr);
		builder.HasData(Salutation.Ms);
		builder.HasData(Salutation.Dr);
		builder.HasData(Salutation.Prof);

	}
}