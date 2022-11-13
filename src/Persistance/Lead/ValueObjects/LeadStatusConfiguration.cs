using Domain.Aggregates.Leads.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Lead.ValueObjects;

public class LeadStatusConfiguration : IEntityTypeConfiguration<LeadStatus>
{
	public void Configure(EntityTypeBuilder<LeadStatus> builder)
	{
		builder
			.ToTable(name: "LeadStatuses");

		builder
			.HasKey(p => p.Value);

		builder
			.Property(p => p.Value)
			.ValueGeneratedNever()
			.IsRequired(required: true);

		builder
			.Property(p => p.Name)
			.IsRequired(required: true)
			.HasMaxLength(maxLength: LeadStatus.MaxLength);

		builder.HasData(LeadStatus.New);
		builder.HasData(LeadStatus.Working);
		builder.HasData(LeadStatus.Contacted);
		builder.HasData(LeadStatus.Qualified);
		builder.HasData(LeadStatus.Unqualified);

	}
}
