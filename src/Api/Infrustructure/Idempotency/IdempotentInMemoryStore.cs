namespace Api.Infrustructure.Idempotency;

public class IdempotentInMemoryStore
{
	public long InsertTime { get; set; }
	public long ExpireTime { get; set; }
	public string IdempotentKey { get; set; }
	public int HttpStatusCode { get; set; }
	public string HttpReposnseBody { get; set; }

}
