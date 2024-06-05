using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Sharp_Apps_Nikita.BankApp;
using C_Sharp_Apps_Nikita.DraftApp;
using C_Sharp_Apps_Nikita.SportApp;
using C_Sharp_Apps_Nikita.Transportation;

namespace C_Sharp_Apps_Nikita.System
{
    public class ProcessManager
    {
        public static int print = 1;
        public static void MainProcess()
        {

            while (print != 0)
            {
                Console.WriteLine("Hi choose your Application u want to use \n" +
                "1 – Bank App | 2 – Sport App | 3 – Transportation App | 4 – Draft App | 0 - Exit");

                print = int.Parse(Console.ReadLine());
                switch (print)
                {
                    case 0:
                        Console.WriteLine("Bye");
                        break;
                    case 1:
                        BankAppMain.MainEntry();
                        break;
                    case 2:
                        SportAppMain.MainEntry();
                        break;
                    case 3:
                        TransportationAppMain.MainEntry();
                        break;
                    case 4:
                        DraftAppMain.MainEntry();
                        break;
                    default:
                        Console.WriteLine("i dont have any Applications in the number u choose try again please");
                        break;
                }
            }
        }

    }
}
