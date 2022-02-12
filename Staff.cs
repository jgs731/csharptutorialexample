using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject2
{
	internal class Staff
	{
		private float hourly_rate;
		private int h_worked;

		public float TotalPay { get; protected set; }
		public float BasicPay  { get; private set; }
		public String NameOfStaff { get; private set; }
		public int HoursWorked
		{
			get
			{
				return h_worked;
			}
			set
			{
				if (value > 0)
					h_worked = value;
				else
					h_worked = 0;
			}
		}
	
		public Staff(String name, float rate)
		{
			NameOfStaff = name;
			hourly_rate = rate;
		}

		public virtual void CalculatePay()
		{
			Console.WriteLine("Calculating pay...");
			BasicPay = h_worked * hourly_rate;
			TotalPay = BasicPay;
		}

		public override String ToString()
		{
			return "\nBasic Pay: " + BasicPay + "\nHourly Rate" + hourly_rate + "\nTotal Pay: " + TotalPay
				+ "\nStaff Name: " + NameOfStaff + "\nHourly rate: " + HoursWorked;
		}
	}
}
