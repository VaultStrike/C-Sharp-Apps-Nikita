using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Final_Project.CargoSpace
{
    public class CargoContainer : IContainable
    {
        //Proparties
        private double maxWeight;
        private double maxVolume;
        private double currentVolume;
        private double currentWeight;
        private List<IPortable> items;

        public List<IPortable> Items { get => items; set => items = value; }

        //Constractors
        public CargoContainer(double maxWeight, double maxVolume)
        {
            this.items = new List<IPortable>();
            this.maxWeight = maxWeight;
            this.maxVolume = maxVolume;
            this.currentVolume = 0;
            this.currentWeight = 0;
        }
        //Methods
        public bool Load(IPortable item)
        {
            if (IsHaveRoom())
            {
                item.Packageitem();
                item.LoadItem();
                items.Add(item);
                currentVolume += (int)item.GetVolume();
                currentWeight += (int)item.GetWeight();
                if (!IsOverload())
                {
                    item.IsLoaded();
                    Console.WriteLine($"Added successfully!\nItem ID:{item.GetId()}\nTotal items: {items.Count}");
                    Console.WriteLine("-------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine($"OVERLOAD WARNING!\nAdded successfully!\nItem ID:{item.GetId()}\nTotal items: {items.Count}");
                    Console.WriteLine("-------------------------------------------------------");
                }
                return true;
            }
            Console.WriteLine("No More Space");
            return false;
        }

        public bool Load(List<IPortable> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (!Load(items[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Unload(IPortable item)
        {
            if (items.Remove(item))
            {
                item.UnLoadItem();
                item.UnPackage();
                currentVolume -= item.GetVolume();
                currentWeight -= item.GetWeight();
                return true;
            }
            return false;
        }

        public bool Unload(List<IPortable> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (!Unload(items[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsHaveRoom()
        {
            return currentVolume < maxVolume;
        }

        public bool IsOverload()
        {
            return currentWeight > maxWeight;
        }
        //Getters
        public double GetMaxVolume()
        {
            return maxVolume;
        }

        public double GetMaxWeight()
        {
            return maxWeight;
        }

        public double GetCurrentVolume()
        {
            return currentVolume;
        }

        public double GetCurrentWeight()
        {
            return currentWeight;
        }

        //לא רוונטי למחלקה למחלקה הזאת
        public string GetPricingList()
        {
            return "";
        }
        public void GetContainerList()
        {
            for(int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i].ToString()); 
            }
        }
        public override string ToString()
        {
            return "";
        }
        public void UpdateItemLocations(StorageStructure newLocation)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].SetLocation(newLocation);
            }
        }
    }
}
