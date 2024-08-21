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
    public class Ship : CargoVehicleTransport, IShippingPriceCalculator
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
        private const double RatePerKM = 20;
        private List<CargoContainer> containers;
        private double currentVolume;
        private double currentWeight;

        public List<CargoContainer> Containers { get => containers; set => containers = value; }

        //private double maximumWeight - נמצה אצל אבא
        //private double maximumVolume נמצה אצל אבא


        public Ship(Driver driver, double maximumWeight, double maximumVolume, StorageStructure current_Port, StorageStructure next_Port, int next_Port_Distance) : base(driver, maximumWeight, maximumVolume, current_Port, next_Port, next_Port_Distance)
        {
            currentVolume = 0; currentWeight = 0;
            containers = new List<CargoContainer>();
            this.cargoType = CargoType.Ship;
        }
        public void AddContainer(CargoContainer container)
        {
            if (currentVolume + container.GetCurrentVolume() < GetMaxVolume())
            {
                containers.Add(container);
                currentVolume += container.GetCurrentVolume();
                currentWeight += container.GetCurrentWeight();
                Console.WriteLine("New Contanier added successfully!");
                if (currentWeight > GetMaxWeight())
                {
                    SetOverWeight(true);
                    SetReadyToGo(false);
                    Console.WriteLine("OVERWIGHT WARRNING!");
                    Console.WriteLine("-------------------------------------------------------");
                }

            }
            else
                Console.WriteLine("Not enough volume to add the container");
        }
        public void RemoveContainer(CargoContainer container)
        {

            containers.Remove(container);
            currentVolume -= container.GetCurrentVolume();
            currentWeight -= container.GetCurrentWeight();
            Console.WriteLine("Contanier removed successfully!");
            Console.WriteLine("-------------------------------------------------------");
            if (currentWeight < GetMaxWeight())
            {
                SetOverWeight(false);
                SetReadyToGo(true);
                Console.WriteLine("Overweight Removed!");
                Console.WriteLine("-------------------------------------------------------");
            }
        }
        public void DisplayContainers()
        {
            for(int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine($"Container : {i+1}");
                containers[i].GetContainerList();
                Console.WriteLine("-------------------------------------------------------");
            }
        }

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
        public int CalculateUnits(IPortable item)
        {
            int units = (int)(item.GetVolume() / 100) + (int)item.GetWeight();
            if (item.IsFragile())
            {
                units *= 2;
            }
            return units;
        }
    }
}

