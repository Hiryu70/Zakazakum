﻿using System;

namespace Zakazakum.Domain.Entities
{
	public class User
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string PhoneNumber { get; set; }

		public string BankName { get; set; }
	}
}
