using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Exam_2
{
    public class TransportationAppMain
    {
        public static void MainEntry()
        {
            Console.WriteLine();
            Console.WriteLine("Name of application is TransportationApp");
            MonitorTransportation monitor = new MonitorTransportation();
            monitor.Test1();
        }
    }
}
