using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Final_Project
{
    public abstract class StorageStructure : IContainable
    {
        private string country;
        private string city;
        private string adress;
        private int numAdress;


        protected StorageStructure(string country, string city, string adress, int numAdress)
        {
            this.country = country;
            this.city = city;
            this.adress = adress;
            this.numAdress = numAdress;
        }
        public string GetCity()
        { return city; }
        public bool Load(IPortable item)
        {
            return false;
        }
        public bool Load(List<IPortable> items)
        {
            return false;
        }
        public bool Unload(IPortable item)
        {
            return false;
        }
        public bool Unload(List<IPortable> items)
        {
            return false; 
        }
        public virtual string GetPricingList()
        {
            return "";
        }

        public bool IsHaveRoom()
        {
            return false; 
        }

        public bool IsOverload()
        {
            return false; 
        }
        public double GetMaxVolume()
        {
            return 0; 
        }
        public double GetMaxWeight()
        {
            return 0; 
        }
        public double GetCurrentVolume()
        {
            return 0;
        }
        public double GetCurrentWeight()
        {
            return 0;
        }
        public override string ToString()
        {
            return $"Country-> {country} | City-> {city} | Address-> {adress} | Address Number-> {numAdress}";
        }

    }
}
