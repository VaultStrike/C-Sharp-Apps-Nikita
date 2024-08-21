using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Final_Project.Items
{
    public class ElectricalItem : Item
    {
        //Proparties
        private int watt;
        private int hDMISlots;
        private int hdmiSlotsUsing;
        //Constractor
        public ElectricalItem(int width, int length, int height, double weight, bool isFragile, StorageStructure currentLocation, int watt, int hDMISlots) : base(width, length, height, weight, isFragile, currentLocation)
        {
            this.watt = watt;
            this.hDMISlots = hDMISlots;
            hdmiSlotsUsing = 0;
        }
        //Methods for Fun
        public void HowManyHDMILeft()
        {
            Console.WriteLine($"You current using {hdmiSlotsUsing}. you left with {hDMISlots-hdmiSlotsUsing} HDMI port/s");
        }
    }
}
