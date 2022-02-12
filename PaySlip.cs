using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject2
{
    internal class PaySlip
    {
        private int year;
        private int month;
        
        enum MonthsOfYear
        {
            JAN = 1, FEB = 2, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC
        }

        public PaySlip(int payMonth, int payYear)
        {
            year = payMonth;
            month = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;
            foreach (Staff f in myStaff)
            {
                path = f.NameOfStaff + ".txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Payslip for {0} {1}", (MonthsOfYear)month, year);
                    sw.WriteLine("============================");
                    sw.WriteLine("Name of staff: {0}", f.NameOfStaff);
                    sw.WriteLine("Hours worked: {0}", f.HoursWorked);
                    sw.WriteLine("");
                    sw.WriteLine("Basic Pay: {0:C}", f.BasicPay);
                    sw.WriteLine("");
                    if (f.GetType() == typeof(Manager))
                       sw.WriteLine("Allowance: {0:C}", ((Manager)f).Allowance);
                    else if (f.GetType() == typeof(Admin))
                        sw.WriteLine("Overtime: {0:C}", ((Admin)f).Overtime);
                    sw.WriteLine("");
                    sw.WriteLine("============================");
                    sw.WriteLine("Total Pay: {0:C}", f.TotalPay);
                    sw.WriteLine("============================");
                    sw.Close();
                }

            }
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            var result =
                from member in myStaff
                where member.HoursWorked < 10
                orderby member.NameOfStaff ascending
                select new {member.NameOfStaff, member.HoursWorked };
            string path = "summary.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");
                foreach (var res in result)
                {
                    sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}", res.NameOfStaff, res.HoursWorked);
                }
                sw.Close();
            }
            
        }

        public override string ToString()
        {
            return "month = " + month + " year = " + year;   
        }
    }
}
