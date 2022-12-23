using Framework.DDD;

namespace Domain.Aggregates.Users;

public class User : IEntity
{
	public User()
	{
		CreatedLeads = new HashSet<Leads.Lead>();
		ModifiedLeads = new HashSet<Leads.Lead>();
		OwnedLeads = new HashSet<Leads.Lead>();

	}

	public Guid Id { get; set; }
	public string Fname { get; set; }
	public string Lname { get; set; }
	public virtual ICollection<Leads.Lead> CreatedLeads { get; set; }
	public virtual ICollection<Leads.Lead> ModifiedLeads { get; set; }
	public virtual ICollection<Leads.Lead> OwnedLeads { get; set; }

}
