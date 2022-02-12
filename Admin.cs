using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject2
{
    internal class Admin : Staff
    {
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30f;

        public float Overtime { get; private set; }
        public Admin(String name) : base (name, adminHourlyRate)
        {
        }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160)
            {
                Overtime = overtimeRate * (HoursWorked - 160);
            } 
        }

        public override string ToString()
        {
            return "\nName Of Staff: " + NameOfStaff + "\nAdmin Hourly rate: " + adminHourlyRate +
                "\nHours worked: " + HoursWorked + "\nBasic Pay: " + BasicPay + "\nOvertime" + Overtime + "\nTotal Pay: " + TotalPay;
        }
    }
}
