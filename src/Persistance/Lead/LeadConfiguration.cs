using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Lead;

public class LeadConfiguration :
	IEntityTypeConfiguration<Domain.Aggregates.Leads.Lead>
{
	public void Configure(EntityTypeBuilder<Domain.Aggregates.Leads.Lead> builder)
	{
		builder.Property(x => x.FirstName)
			.HasConversion(x => x.Value, x => Domain.SharedKernel.FirstName.Create(x));

		builder.Property(x => x.LastName)
			.IsRequired()
			.HasConversion(x => x.Value,x => Domain.SharedKernel.LastName.Create(x));

		builder.OwnsOne(x => x.FullName, b =>
		{
			b.HasOne(x => x.Salutation).WithMany().HasForeignKey("SalutationId").IsRequired(false);

			b.Property<int>("SalutationId").HasColumnName("SalutationId"); // Fix The Column name in DB

		});

		builder.HasOne(x => x.Industry).WithMany().HasForeignKey("IndustryId").IsRequired(false);
		builder.HasOne(x => x.LeadSource).WithMany().HasForeignKey("LeadSourceId").IsRequired(false);
		builder.HasOne(x => x.LeadStatus).WithMany().HasForeignKey("LeadStatusId").IsRequired(false);
		builder.HasOne(x => x.Rating).WithMany().HasForeignKey("RatingId").IsRequired(false);

		builder.Property(x => x.Company).IsRequired().HasMaxLength(255);

		builder.Property(x => x.Email)
			.HasConversion(x => x.Value, x => Domain.SharedKernel.EmailAddress.Create(x));

		builder.Property(x => x.Title).HasMaxLength(50);
		builder.Property(x => x.Mobile).HasMaxLength(50);
		builder.Property(x => x.Phone).HasMaxLength(50);
		builder.Property(x => x.City).HasMaxLength(50);
		builder.Property(x => x.Country).HasMaxLength(50);
		builder.Property(x => x.Website).HasMaxLength(100);
		builder.Property(x => x.Street).HasMaxLength(100);
		builder.Property(x => x.State).HasMaxLength(10);
		builder.Property(x => x.PostalCode).HasMaxLength(50);
		builder.Property(x => x.Description).HasMaxLength(500);
		builder.Property(x => x.AnnualRevenue).HasPrecision(2);
	}

}