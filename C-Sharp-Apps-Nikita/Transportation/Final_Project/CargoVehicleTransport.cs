using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Final_Project
{
    public abstract class CargoVehicleTransport : IContainable
    {
        private Driver driver;
        private double maximumWeight;
        private double maximumVolume;
        private bool ready_To_Go;
        private bool over_Weight;
        private StorageStructure current_Port;
        private StorageStructure next_Port;
        private int next_Port_Distance;
        private double price;
        private int id;
        private List<IPortable> items;
        protected CargoType cargoType;

        public StorageStructure Current_Port { get => current_Port; set => current_Port = value; }
        public StorageStructure Next_Port { get => next_Port; set => next_Port = value; }

        protected CargoVehicleTransport(Driver driver, double maximumWeight, double maximumVolume, StorageStructure current_Port, StorageStructure next_Port, int next_Port_Distance)
        {
            items = new List<IPortable>();
            this.id = new Random().Next(1000, 10000);
            this.ready_To_Go = false;
            this.over_Weight = false;
            this.driver = driver;
            this.maximumWeight = maximumWeight;
            this.maximumVolume = maximumVolume;
            this.current_Port = current_Port;
            this.next_Port = next_Port;
            this.next_Port_Distance = next_Port_Distance;
            this.price = 0;
            this.cargoType = CargoType.Null;

        }

        public int GetNextPortDistance()
        {
            return next_Port_Distance;
        }
        public bool Load(IPortable item)
        {
            if (IsHaveRoom() && !IsOverload())
            {
                //אופציה להוסיף הדפסה על הצלחת המטען
                items.Add(item);
                return true;
            }
            return false;
        }

        public bool Load(List<IPortable> items)
        {
            //אופציה להוסיף הדפסה על הצלחת המטען
            for (int i = 0; i < items.Count; i++)
            {
                if (!Load(items[i]))
                    return false;
            }
            return true;
        }

        public bool Unload(IPortable item)
        {
            return items.Remove(item);
        }

        public bool Unload(List<IPortable> items)
        {
            bool allRemoved = true;
            for (int i = 0; i < items.Count; i++)
            {
                if (!Unload(items[i]))
                    allRemoved = false;
            }
            return allRemoved;
        }

        public bool IsHaveRoom()
        {
            return GetCurrentVolume() < GetMaxVolume();
        }

        public bool IsOverload()
        {
            return GetCurrentWeight() > GetMaxWeight();
        }

        public double GetMaxVolume()
        {
            return maximumVolume;
        }

        public double GetMaxWeight()
        {
            return maximumWeight;
        }

        public double GetCurrentVolume()
        {
            int currentVolume = 0;
            for (int i = 0; i < items.Count; i++)
            {
                currentVolume += (int)items[i].GetVolume();
            }
            return currentVolume;
        }
        public double GetCurrentWeight()
        {
            int currentWeight = 0;
            for (int i = 0; i < items.Count; i++)
            {
                currentWeight += (int)items[i].GetWeight();
            }
            return currentWeight;
        }
        public bool GetOverWeight()
        {
            return over_Weight;
        }
        public void SetOverWeight(bool set)
        {
            over_Weight = set;
        }
        public bool GetReadyToGo()
        {
            return ready_To_Go;
        }
        public void SetReadyToGo(bool set)
        {
            ready_To_Go = set;
        }
        public string GetPricingList()
        {
            return "";
        }
        public void SetDriver(Driver driverType)
        {
            driver = driverType;
        }
        public void ReadyToGo()
        {
            if (driver.Approve(cargoType, next_Port) && !GetOverWeight())
            {
                ready_To_Go = true;
                Console.WriteLine($"{cargoType} Ready To Go!");
            }
            else
            {
                ready_To_Go = false;
                if (GetOverWeight())
                {
                    Console.WriteLine("Can't Approve You are Over Weight!");
                }
                else
                {
                    Console.WriteLine("Driver Didn't Approve!");
                }
            }
        }
        public void GoToNextDestination()
        {
            ReadyToGo();
            if (next_Port == null)
            {
                Console.WriteLine("You don't have a destination!");
                Console.WriteLine("-------------------------------------------------------");
            }
            else if (ready_To_Go)
            {
                current_Port = next_Port;
                next_Port = null;
                Console.WriteLine($"You have arrived at your destination: {current_Port.GetCity()}");
                Console.WriteLine("-------------------------------------------------------");
            }
        }

        public void SetNextDestination(StorageStructure nextDestination)
        {
            next_Port= nextDestination;
            Console.WriteLine($"Next Destination=> {nextDestination}");
            Console.WriteLine("-------------------------------------------------------");
        }
    }
}
