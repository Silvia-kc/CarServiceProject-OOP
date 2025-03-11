using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    public class Repairs
    {
		private DateTime dateIn;
		public DateTime DateIn
		{
			get { return dateIn; }
			set { dateIn = value; }
		}
        private DateTime dateOut;
        public DateTime DateOut
        {
            get { return dateOut; }
            set { dateOut = value; }
        }
		private double totalCost;
		public double TotalCost
		{
			get { return totalCost; }
			set { totalCost = value; }
		}
		private string repairType;
		public string RepairType
		{
			get { return repairType; }
			set { repairType = value; }
		}
		private Vehicles vehicle;

		public Vehicles Vehicle
		{
			get { return vehicle; }
			set { vehicle = value; }
		}
		public Repairs(DateTime dateIn, DateTime dateOut, double totalCost, string repairType, Vehicles vehicle)
		{
			DateIn= dateIn;
			DateOut= dateOut;
			TotalCost= totalCost;
			RepairType= repairType;
			Vehicle = vehicle;
		}
	}
}
