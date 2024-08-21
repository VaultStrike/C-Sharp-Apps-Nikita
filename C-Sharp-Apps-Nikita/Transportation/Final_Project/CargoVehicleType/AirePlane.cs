using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using C_Sharp_Apps_Nikita.Transportation.Final_Project.CargoSpace;

namespace C_Sharp_Apps_Nikita.Transportation.Final_Project.CargoVehicleType
{
    public class AirePlane : CargoVehicleTransport, IShippingPriceCalculator
    {
        //Base: Proparties
        /*
        private Driver driver;
        private double maximumWeight;
        private double maximumVolume;
        private bool ready_To_Go;
        private bool over_Weight;
        private string current_Port;
        private string next_Port;
        private int next_Port_Distance;
        private double price;
        private int id;
        private List<IPortable> items;
        protected CargoType cargoType;
        */
        //Proparties
        private const double RatePerKM = 50;
        private CargoContainer planeCargo;
        //Getter/Setter
        public CargoContainer PlaneCargo { get => planeCargo; set => planeCargo = value; }
        //Constractor
        public AirePlane(Driver driver, double maximumWeight, double maximumVolume, StorageStructure current_Port, StorageStructure next_Port, int next_Port_Distance) : base(driver, maximumWeight, maximumVolume, current_Port, next_Port, next_Port_Distance)
        {
            planeCargo = new CargoContainer(maximumWeight, maximumVolume);
            this.cargoType = CargoType.Airplane;
        }
        //Methods
        public double CalculatePrice(IPortable item, int travelDistance)
        {
            int units = CalculateUnits(item);
            return units * travelDistance * RatePerKM;
        }

        public double CalculatePrice(List<IPortable> items, int travelDistance)
        {
            int totalUnits = 0;
            for (int i = 0; i < items.Count; i++)
            {
                totalUnits += CalculateUnits(items[i]);
            }
            return totalUnits * travelDistance * RatePerKM;
        }

        private int CalculateUnits(IPortable item)
        {
            int units = (int)(item.GetVolume() / 100) + (int)item.GetWeight();
            if (item.IsFragile())
            {
                units *= 2;
            }
            return units;
        }
        public double CalPricePlane()
        {
            return CalculatePrice(planeCargo.Items, GetNextPortDistance());
        }
        public void DisplayCargo()
        {
            Console.WriteLine($"Number of items in cargo: {planeCargo.Items.Count}");
            for (int i = 0; i < planeCargo.Items.Count; i++)
            {
                Console.WriteLine(planeCargo.Items[i]);
            }
            Console.WriteLine("");
            UpdateWeight();
            Console.WriteLine("-------------------------------------------------------");
        }

        public void UpdateWeight()
        {
            if(planeCargo.GetCurrentWeight() > GetMaxWeight())
            {
                SetOverWeight(true);
                Console.WriteLine($"OVERLOAD WARNING!\nCurrent Weight:{planeCargo.GetCurrentWeight()} | Vehicle Max Weight:{GetMaxWeight()}");
            }
            else
            {
                Console.WriteLine($"\nCurrent Weight:{planeCargo.GetCurrentWeight()} | Vehicle Max Weight:{GetMaxWeight()}");
            }
        }


    }

}
