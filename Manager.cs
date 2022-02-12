using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject2
{
    internal class Manager : Staff
    {
        private const float managerHourlyRate = 50;

        public int Allowance { get; private set; }

        public Manager(String name) : base (name, managerHourlyRate)
        {
        }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked > 160)
            {
                TotalPay = BasicPay + Allowance;
            }
        }

        public override string ToString()
        {
            return "\nBasic Pay: " + BasicPay + "\nManager Hourly Rate" + managerHourlyRate + "\nTotal Pay: " + TotalPay
            + "\nStaff Name: " + NameOfStaff + "\nAllowance" + Allowance + "\nHourly rate: " + HoursWorked;
        }
    }
}
