using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Final_Project
{
    public class Port : StorageStructure
    {
        private double maximumWeight;
        private double maximumVolume;
        private List<IPortable> items;
        private CargoType storageType;
        public Port(CargoType driverType, string country, string city, string address, int numAddress): base(country, city, address, numAddress)
        {
            maximumWeight = 150_000; maximumVolume = 150_000;//כרגע זה המקסימום
            this.storageType = driverType;
            this.items = new List<IPortable>();
        }
        public bool Load(IPortable item)
        {
            return true;
        }
        public bool Load(List<IPortable> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                return false;
            }
            return true;
        }
        public bool UnLoad(IPortable item)
        {
            return true;
        }
        public bool Unload(List<IPortable> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                return true;
            }
            return false;
        }

        public override string GetPricingList()
        {
            return "";
        }
    }
}
