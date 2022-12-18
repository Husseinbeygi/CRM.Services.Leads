namespace Api.Helpers
{
	public static class HelperExtensionRegistery
	{
		public static IServiceCollection AddCurrentContextHelper(this IServiceCollection services)
		{
			return services.AddTransient(typeof(CurrentContextHelper));
		}

	}
}
