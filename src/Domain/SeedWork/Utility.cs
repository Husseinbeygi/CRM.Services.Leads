namespace Domain.SeedWork
{
	public static class Utility
	{
		static Utility()
		{
		}

		public static System.DateTime Now
		{
			get
			{
				return System.DateTime.Now;
			}
		}

		public static System.DateTime Today
		{
			get
			{
				return Now.Date;
			}
		}
	}
}
