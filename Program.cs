using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar1
{
    class Program
    {
        //перечислення присвоєння констант 
        public enum Months
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }
	    //вивід календаря з роком і місяцем
        public static void ShowYearMonth(int yearnumber, int monthnumber)
        {
            Calendar myCal = CultureInfo.InstalledUICulture.Calendar;
            DateTime myDT = new DateTime(yearnumber, monthnumber, 1, myCal);
            
            int i = monthnumber;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"       {(Months)i} ");
            Console.WriteLine("Mo Tu We Th Fr Sa Su");
            int month = myCal.GetMonth(myDT);
            int j = Convert.ToInt32(myCal.GetDayOfWeek(myDT)) - 1 ;
            for (int m = 0; m < j; m++)
            { 
		    Console.Write("   ");
            }
            while (myCal.GetMonth(myDT) == month)
            {
                if (j == -1)
                {
                    j = 6;
                    for (int m = 0; m < j; m++)
                    {
                        Console.Write("   ");
                    }
                }
                //if (j == -2)
                //{
                //    j = 5;
                //    for (int m = 0; m < j; m++)
                //    {
                //        Console.Write("   ");
                //    }
                //}
                if (j % 7 == 0)
                {
                    Console.WriteLine();
                }
                string space = (myDT.Day.ToString().Length > 1) ? " " : "  ";
                Console.Write(myDT.Day + space);
                myDT = myDT.AddDays(1);
                j++;
                }
                Console.WriteLine();
                Console.WriteLine();
            }
	public static void ShowYear(int yearnumber)
        {
            Calendar myCal = CultureInfo.InstalledUICulture.Calendar;
            DateTime myDT = new DateTime(yearnumber, 1, 1, myCal);
            Console.WriteLine($"       {yearnumber} ");
            for (int i = 1; i < 13; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"       {(Months)i} ");
                Console.WriteLine("Mo Tu We Th Fr Sa Su");
                int month = myCal.GetMonth(myDT);
                int j = Convert.ToInt32(myCal.GetDayOfWeek(myDT)) - 1;
                for (int m = 0; m < j; m++)
                {
                    Console.Write("   ");
                }
                while (myCal.GetMonth(myDT) == month)
                {
                    if (j == -1)
                    {
                        j = 6;
                        for (int m = 0; m < j; m++)
                        {
                            Console.Write("   ");
                        }
                    }
                    if (j % 7 == 0)
                    {
                        Console.WriteLine();
                    }
                    string space = (myDT.Day.ToString().Length > 1) ? " " : "  ";
                    Console.Write(myDT.Day + space);
                    myDT = myDT.AddDays(1);
                    j++;
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
	public static void Menu()
        {
	    string date = Convert.ToString(DateTime.Now);
            string[] arr = date.Split(new char[] { '.', ' ' });
            int yearnow = Convert.ToInt32(arr[2]);
            int monthnow = Convert.ToInt32(arr[1]);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string action = Console.ReadLine();

            string[] words = action.Split(new char[] { ' ' });

            if (action == "$ cal")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"       {yearnow} ");
                ShowYearMonth(yearnow, monthnow);
            }
 	   if (action == "$ cal --help")
           {
                Console.WriteLine("\n \n$ cal: Shows current month calendar on the terminal");
                Console.WriteLine("$ cal [month] [year] : Shows calendar of selected month and year");
                Console.WriteLine("$ cal [year] : Shows the whole calendar of the year");
                Console.WriteLine("$ cal -3 : Shows calendar of previous, current and next month");
            }
            if (action == "$ cal -3")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"       {yearnow} ");
                ShowYearMonth(yearnow, monthnow-1);
                ShowYearMonth(yearnow, monthnow);
                ShowYearMonth(yearnow, monthnow+1);
            }

            if (action != "$ cal" && action != "$ cal --help" && action != "$ cal -3")
            {
                if (words.Length==3)
                {
                    int yearRead = Convert.ToInt32(words[2]);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    ShowYear(yearRead);
                }
                if (words.Length==4)
                {
                    int yearRead = Convert.ToInt32(words[2]);
                    int monthRead = Convert.ToInt32(words[3]);
                    ShowYearMonth(yearRead, monthRead);
                }
	    }
	}
        static void Main(string[] args)
        {
            Console.Title = "Terminal";
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Menu();
            }
            Console.ReadLine();
        }
    }
}

