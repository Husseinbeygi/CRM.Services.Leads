using Domain.Aggregates.Leads.ValueObjects;

namespace Domain.Aggregates.Leads;

public class Lead : SeedWork.AggregateRoot
{

        public SharedKernel.FirstName FirstName { get; set; }
        public SharedKernel.LastName LastName { get; set; }
        public SharedKernel.FullName FullName { get; set; }
        public string Company { get; set; }
        public SharedKernel.EmailAddress Email { get; set; }
        public string Title { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public Guid OwnerId { get; set; }
        public long ModifiedAt { get; set; }
        public Guid ModifiedById { get; set; }
        public long CreatedAt { get; set; }
        public Guid CreatedById { get; set; }
        public LeadStatus Status { get; set; }
        public string AnnualRevenue { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public Industry Industry { get; set; }
        public LeadSource LeadSource { get; set; }
        public int NumberOfEmployees { get; set; }
        public string PostalCode { get; set; }
        public Rating Rating { get; set; }
        public SharedKernel.Salutation Salutation { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Website { get; set; }
        public Guid TenantId { get; set; }


}
