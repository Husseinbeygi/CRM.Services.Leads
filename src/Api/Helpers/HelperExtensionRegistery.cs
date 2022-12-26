namespace Api.Helpers
{
	public static class HelperExtensionRegistery
	{
		public static IServiceCollection AddHttpContextHelper(this IServiceCollection services)
		{
			return services.AddTransient(typeof(CurrentContextHelper));
		}

	}
}
