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
	public static void Menu()
        {
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
