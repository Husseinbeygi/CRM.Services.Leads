namespace IntegrationTests.Models
{
	public class Leads
	{
		public Guid id { get; set; }
		public double annualRevenue { get; set; }
		public string city { get; set; }
		public string company { get; set; }
		public string country { get; set; }
		public object createdAt { get; set; }
		public string createdById { get; set; }
		public string description { get; set; }
		public string email { get; set; }
		public string firstName { get; set; }
		public string fullName { get; set; }
		public ValueObject industry { get; set; }
		public string lastName { get; set; }
		public ValueObject leadSource { get; set; }
		public ValueObject leadStatus { get; set; }
		public string mobile { get; set; }
		public object modifiedAt { get; set; }
		public string modifiedById { get; set; }
		public int numberOfEmployees { get; set; }
		public string ownerId { get; set; }
		public string phone { get; set; }
		public string postalCode { get; set; }
		public ValueObject rating { get; set; }
		public ValueObject salutaion { get; set; }
		public string state { get; set; }
		public string street { get; set; }
		public string tenantId { get; set; }
		public string title { get; set; }
		public string website { get; set; }
	}




}
