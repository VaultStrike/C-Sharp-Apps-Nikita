using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Sharp_Apps_Nikita.BankApp;
using C_Sharp_Apps_Nikita.DraftApp;
using C_Sharp_Apps_Nikita.SportApp;
using C_Sharp_Apps_Nikita.Transportation.Final_Project;

namespace C_Sharp_Apps_Nikita.Transportation
{
    public class TransportationAppMain
    {
        public static int print = 1;
        public static void MainEntry()
        {

            Console.WriteLine();
            Console.WriteLine("Name of application is TransportationApp");
            Console.WriteLine("How Can I Help?");
            Console.WriteLine();
            while (print != 0)
            {
                Console.WriteLine("Application u want to use \n" +
                "1 – Run All Tests | 0 - Exit");

                print = int.Parse(Console.ReadLine());
                switch (print)
                {
                    case 0:
                        Console.WriteLine("Bye");
                        break;
                    case 1:
                        ProjectTest.RunAllTests();
                        break;
                    default:
                        Console.WriteLine("Wrong Input!");
                        break;
                }
            }

        }
    }
}
