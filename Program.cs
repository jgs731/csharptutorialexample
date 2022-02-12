
using CSProject2;

class Program {
    static void Main(String[] args) {
        List<Staff> myStaff = new List<Staff>();
        FileReader fr = new FileReader();
        int month = 0, year = 0;

        while (year == 0)
        {
            Console.Write("\nPlease enter the year: ");
            try
            {
                year = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e) 
            {
                Console.Write(e.Message + " Year format is incorrect. Please try again!");
            }
        }

        while (month == 0)
        {
            Console.Write("\nPlease enter the month: ");
            try
            {
                month = Convert.ToInt32(Console.ReadLine());
                if (month < 1 || month > 12)
                {
                    Console.Write("Non-existent month entered. Values are 1-12. Please try again!");
                    month = 0;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message + "Month format is incorrect. Please try again!");
            }
        }
        myStaff = fr.readFile();

        for (int i = 0; i < myStaff.Count; i++)
        {
            try
            {
                Console.Write("Please enter hours worked for {0}: ", myStaff[i].NameOfStaff); // this is the line fucking up
                myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                myStaff[i].CalculatePay();
                Console.WriteLine(myStaff[i].ToString());

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                i--;
            }
        }

        PaySlip ps = new PaySlip(month, year);
        ps.GeneratePaySlip(myStaff);
        ps.GenerateSummary(myStaff);
        Console.Read();

    }
}   
