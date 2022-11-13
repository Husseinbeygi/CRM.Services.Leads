using Domain.Aggregates.Leads.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Lead.ValueObjects;

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
	public void Configure(EntityTypeBuilder<Rating> builder)
	{
		builder
			.ToTable(name: "Rating");

		builder
			.HasKey(p => p.Value);

		builder
			.Property(p => p.Value)
			.ValueGeneratedNever()
			.IsRequired(required: true);

		builder
			.Property(p => p.Name)
			.IsRequired(required: true)
			.HasMaxLength(maxLength: Rating.MaxLength);

		builder.HasData(Rating.Cold);
		builder.HasData(Rating.Warm);
		builder.HasData(Rating.Hot);

	}
}
