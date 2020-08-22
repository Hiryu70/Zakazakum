using System;

namespace Zakazakum.Application.Common.Exceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException(string name, object key)
			: base($"Entity \"{name}\" ({key}) was not found.")
		{
		}
	}
}