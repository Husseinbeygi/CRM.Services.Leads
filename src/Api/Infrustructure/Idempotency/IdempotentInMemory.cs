namespace Api.Infrustructure.Idempotency
{
	public class IdempotentInMemory
	{
		List<IdempotentInMemoryStore> idempotentStore { get; set; } = new();


		public void AddNewrequest(string idempotencyKey)
		{
			idempotentStore.Add(
				new IdempotentInMemoryStore
				{
					InsertTime = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
					ExpireTime = DateTimeOffset.Now.AddDays(1).ToUnixTimeMilliseconds(),
					IdempotentKey = idempotencyKey
				}); ;
		}

		public void Updaterequest(string idempotencyKey, int statusCode, string body)
		{
			if (string.IsNullOrWhiteSpace(idempotencyKey)) { return; }

			var res = idempotentStore.FirstOrDefault(x => x.IdempotentKey == idempotencyKey);
			if (res is null)
			{
				return;
			}
			res.HttpStatusCode = statusCode;
			res.HttpReposnseBody = body;

		}

		public bool CheckForRequest(string idempotencyKey)
		{
			var storecheck = idempotentStore.
				FirstOrDefault(x => x.IdempotentKey == idempotencyKey);

			if (storecheck != null)
			{
				return true;
			};

			return false;
		}

	}
}
