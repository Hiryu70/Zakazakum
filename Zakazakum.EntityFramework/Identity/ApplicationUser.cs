using Microsoft.AspNetCore.Identity;

namespace Zakazakum.EntityFramework
{
	public class ApplicationUser : IdentityUser
	{
		public string Name { get; set; }

		public string BankName { get; set; }
	}
}
