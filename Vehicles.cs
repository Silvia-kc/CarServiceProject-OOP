using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    public class Vehicles
    {
		private string brand;
		public string Brand
		{
			get { return brand; }
			set { brand = value; }
		}
		private string model;
		public string Model
		{
			get { return model; }
			set { model = value; }
		}
		private int yearOfManifacture;
		public int YearOfManifacture
		{
			get { return yearOfManifacture; }
			set { yearOfManifacture = value; }
		}
		private string licensePlate;
		public string LicensePlate
		{
			get { return licensePlate; }
			set { licensePlate = value; }
		}
		private Clients client;
		public Clients Client
		{
			get { return client; }
			set { client = value; }
		}
		public Vehicles(string brand, string model, int yearOfManifacture, string licensePlate, Clients client)
		{
			Brand = brand;
			Model = model;
			YearOfManifacture= yearOfManifacture;
			LicensePlate = licensePlate;
			Client = client;
		}
	}
}
