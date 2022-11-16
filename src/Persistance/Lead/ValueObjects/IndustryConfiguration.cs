using Domain.Aggregates.Leads.ValueObjects;
using Domain.SharedKernel;

namespace Persistence.Lead.ValueObjects;

public class IndustryConfiguration : IEntityTypeConfiguration<Industry>
{
	public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Industry> builder)
	{
		builder
			.ToTable(name: "Industries");

		builder
			.HasKey(p => p.Value);

		builder
			.Property(p => p.Value)
			.ValueGeneratedNever()
			.IsRequired(required: true);

		builder
			.Property(p => p.Name)
			.IsRequired(required: true)
			.HasMaxLength(maxLength: Industry.MaxLength);

		builder.HasData(Industry.None);
		builder.HasData(Industry.Agriculture);
		builder.HasData(Industry.Apparel);
		builder.HasData(Industry.Banking);
		builder.HasData(Industry.Biotechnology);
		builder.HasData(Industry.Chemicals);
		builder.HasData(Industry.Communications);
		builder.HasData(Industry.Construction);
		builder.HasData(Industry.Consulting);
		builder.HasData(Industry.Education);
		builder.HasData(Industry.Electronics);
		builder.HasData(Industry.Energy);
		builder.HasData(Industry.Engineering);
		builder.HasData(Industry.Entertainment);
		builder.HasData(Industry.Environmental);
		builder.HasData(Industry.Finance);
		builder.HasData(Industry.Government);
		builder.HasData(Industry.Healthcare);
		builder.HasData(Industry.Hospitality);
		builder.HasData(Industry.Insurance);
		builder.HasData(Industry.Machinery);
		builder.HasData(Industry.Manufacturing);
		builder.HasData(Industry.Media);
		builder.HasData(Industry.NotForProfit);
		builder.HasData(Industry.Retail);
		builder.HasData(Industry.Shipping);
		builder.HasData(Industry.Technology);
		builder.HasData(Industry.Telecommunications);
		builder.HasData(Industry.Transportation);
		builder.HasData(Industry.Utilities);
		builder.HasData(Industry.Recreation);
		builder.HasData(Industry.Other);

	}
}
