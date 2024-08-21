using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Final_Project.Items
{
    public class GeneralItem : Item
    {
        public GeneralItem(int width, int length, int height, double weight, bool isFragile, StorageStructure currentLocation) : base(width, length, height, weight, isFragile, currentLocation)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
