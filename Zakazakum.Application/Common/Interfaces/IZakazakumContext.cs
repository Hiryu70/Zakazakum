using Microsoft.EntityFrameworkCore;
using Zakazakum.Domain;
using Zakazakum.Domain.Entities;

namespace Zakazakum.Application.Common.Interfaces
{
	public interface IZakazakumContext
	{
		DbSet<Meal> Meals { get; set; }
	}
}