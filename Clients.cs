using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    public class Clients
    {
		private string firstName;
		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}
		private string lastName;
		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}
		private string phoneNumber;
		public string PhoneNumber
		{
			get { return phoneNumber; }
			set { phoneNumber = value; }
		}
		private string email;
		public string Email
		{
			get { return email; }
			set { email = value; }
		}
		public Clients(string firstName, string lastName, string phoneNumber, string email)
		{
			FirstName = firstName;
			LastName = lastName;
			PhoneNumber = phoneNumber;
			Email = email;
		}
	}
}
