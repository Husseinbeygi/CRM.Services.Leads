using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Lead;

public class LeadConfiguration :
	IEntityTypeConfiguration<Domain.Aggregates.Leads.Lead>
{
	public void Configure(EntityTypeBuilder<Domain.Aggregates.Leads.Lead> builder)
	{
		builder.Property(x => x.VersionNumber)
		.IsRequired()
		.ValueGeneratedOnAddOrUpdate();

		builder.Property(x => x.Code)
		 .IsRequired()
		 .ValueGeneratedOnAdd();

		builder.Property(x => x.FirstName)
			.IsRequired(false)
			.HasConversion(x => x.Value,
			x => Domain.SharedKernel.FirstName.Create(x));

		builder.Property(x => x.LastName)
			.IsRequired()
			.HasConversion(x => x.Value, 
			x => Domain.SharedKernel.LastName.Create(x));

		builder.HasOne(x => x.Salutation)
			.WithMany()
			.HasForeignKey("SalutationId")
			.IsRequired(false)
			.OnDelete(DeleteBehavior.NoAction);

		builder.HasOne(x => x.Industry)
			.WithMany()
			.HasForeignKey("IndustryId")
			.IsRequired(false)
			.OnDelete(DeleteBehavior.NoAction);

		builder.HasOne(x => x.LeadSource)
			.WithMany()
			.HasForeignKey("LeadSourceId")
			.IsRequired(false)
			.OnDelete(DeleteBehavior.NoAction);

		builder.HasOne(x => x.LeadStatus)
			.WithMany()
			.HasForeignKey("LeadStatusId")
			.IsRequired(false)
			.OnDelete(DeleteBehavior.NoAction);

		builder.HasOne(x => x.Rating)
			.WithMany()
			.HasForeignKey("RatingId")
			.IsRequired(false)
			.OnDelete(DeleteBehavior.NoAction);

		builder.Property(x => x.Company).IsRequired().HasMaxLength(255);

		builder.Property(x => x.Email)
			.IsRequired(false)
			.HasConversion(x => x.Value, x => Domain.SharedKernel.EmailAddress.Create(x));

		builder.HasOne(x => x.CreatedBy)
		 .WithMany(x => x.CreatedLeads)
		 .IsRequired()
		 .HasForeignKey(x => x.CreatedById)
		 .OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.ModifiedBy)
		 .WithMany(x => x.ModifiedLeads)
		 .IsRequired()
		 .HasForeignKey(x => x.ModifiedById)
		 .OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.Owner)
		 .WithMany(x => x.OwnedLeads)
		 .IsRequired()
		 .HasForeignKey(x => x.OwnerId)
		 .OnDelete(DeleteBehavior.Restrict);


		builder.HasQueryFilter(x => 
		EF.Property<Guid>
		(x,nameof(Domain.Aggregates.Leads.Lead.TenantId)) == x.TenantId);

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
		builder.Property(x => x.AnnualRevenue).HasPrecision(28, 8);
	}

}