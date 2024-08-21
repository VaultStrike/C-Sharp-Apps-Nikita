using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Final_Project
{
    public interface IContainable
    {
        public bool Load(IPortable item);
        public bool Load(List<IPortable> items);
        public bool Unload(IPortable item);
        public bool Unload(List<IPortable> items);

        public string GetPricingList();
        public bool IsHaveRoom();
        bool IsOverload();
        public double GetMaxVolume();
        public double GetMaxWeight();
        public double GetCurrentVolume();
        public double GetCurrentWeight();
    }
}
