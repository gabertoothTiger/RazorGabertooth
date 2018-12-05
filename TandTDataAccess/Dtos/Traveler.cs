using System;
using System.Collections.Generic;
using System.Text;

namespace TandTDataAccess.Dtos
{
	public class Traveler
	{
		public Traveler(int id, string firstName, string lastName)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
		}
		public int Id { get; }
		public string FirstName { get; }
		public string LastName { get; }
	}
}
