using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Final_Project
{
    public interface IShippingPriceCalculator
    {
        public double CalculatePrice(IPortable item, int travelDistance);
        public double CalculatePrice(List<IPortable> items, int travelDistance);
    }
}
