using Domain.Aggregates.Leads.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Lead.ValueObjects;

public class LeadSourceConfiguration : IEntityTypeConfiguration<LeadSource>
{
	public void Configure(EntityTypeBuilder<LeadSource> builder)
	{
		builder
			.ToTable(name: "LeadSources");

		builder
			.HasKey(p => p.Value);

		builder
			.Property(p => p.Value)
			.ValueGeneratedNever()
			.IsRequired(required: true);

		builder
			.Property(p => p.Name)
			.IsRequired(required: true)
			.HasMaxLength(maxLength: LeadSource.MaxLength);

		builder.HasData(LeadSource.None);
		builder.HasData(LeadSource.ExternalReferral);
		builder.HasData(LeadSource.Advertisement);
		builder.HasData(LeadSource.Wordofmouth);
		builder.HasData(LeadSource.InStore);
		builder.HasData(LeadSource.OnSite);
		builder.HasData(LeadSource.Social);
		builder.HasData(LeadSource.Web);
	}
}
