using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Sharp_Apps_Nikita.Transportation.Final_Project.CargoSpace;

namespace C_Sharp_Apps_Nikita.Transportation.Final_Project.CargoVehicleType
{
    public class Train :  CargoVehicleTransport, IShippingPriceCalculator
    {
        private const double RatePerKM = 5;
        private List<Crone> crones;
        private double currentVolume;
        private double currentWeight;

        public Train(Driver driver, double maximumWeight, double maximumVolume, StorageStructure current_Port, StorageStructure next_Port, int next_Port_Distance)
            : base(driver, maximumWeight, maximumVolume, current_Port, next_Port, next_Port_Distance)
        {
            crones = new List<Crone>();
            currentVolume = 0;
            currentWeight = 0;
            cargoType = CargoType.Train;
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

        public void AddCrone(Crone newcrone)
        {
                crones.Add(newcrone);
                currentVolume += newcrone.GetCurrentVolume();
                currentWeight += newcrone.GetCurrentWeight();
                Console.WriteLine("New crone added successfully!");
                if (currentWeight >= GetMaxWeight())
                {
                    SetOverWeight(true);
                    SetReadyToGo(false);
                    Console.WriteLine("OVERWIGHT WARRNING!");
                }
  
        }
        public void RemoveCrone(Crone newcrone)
        {
            crones.Remove(newcrone);
            currentVolume -= newcrone.GetCurrentVolume();
            currentWeight -= newcrone.GetCurrentWeight();
            Console.WriteLine("Crone removed successfully!");
            if (IsOverload() && !GetOverWeight())
            {
                SetOverWeight(true);
                SetReadyToGo(false);
                Console.WriteLine("Overweight Removed!");
            }
        }
        public List<Crone> GetCrones()
        {
            return crones;
        }


        public void DisplayCrones()
        {
            for (int i = 0; i < crones.Count; i++)
            {
                Console.WriteLine($"Crone : {i + 1}");
                crones[i].GetCroneList();
                Console.WriteLine("-------------------------------------------------------");
            }
        }
    }
}
