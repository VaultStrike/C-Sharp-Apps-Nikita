using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Final_Project
{
    public class Driver
    {
        //Proparties
        private string name;
        private string lastName;
        private string id;
        private CargoType driverType;

        //Getters/Setters
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Id { get => id; set => id = value; }
        public CargoType DriverType { get => driverType; set => driverType = value; }
        //Constractors
        public Driver()//empty
        {
        }
        public Driver(string name, string lastName, string id, CargoType driverType)
        {
            this.name = name;
            this.lastName = lastName;
            this.id = id;
            this.driverType = driverType;
        }
        public bool Approve(CargoType cargoType, StorageStructure nextDestination)
        {
            bool driverIsReady = false;//flag that checks if the driver is ready or not.
            string answerPrint = "ready";//Prints the reason for refuse (Driver not ready || Driver are not authorized to drive this type vehicle. 
            Console.WriteLine($"Driver {Name} {LastName} you feel good and ready to go? (y/n) ");
            char driverAnswer = char.Parse(Console.ReadLine());
            Console.WriteLine("-------------------------------------------------------");
            //flag
            if (driverAnswer == 'y')
            {
                driverIsReady = true;
                answerPrint = "authorized";
            }

            if (cargoType == driverType && driverIsReady)
            {
                Console.WriteLine($"Driver {Name} {LastName} approves the vehicle for the next destination:\n {nextDestination}");
                Console.WriteLine("-------------------------------------------------------");
                return true;
            }
            else
            {
                //Prints the reason for refuse
                Console.WriteLine($"Driver {Name} {LastName} is not {answerPrint} to approve this type of vehicle.");
                return false;
            }

        }
    }
}
