using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Final_Project.Items
{
    public class Furniture :Item
    {
        //Proparties
        private bool isModular;
        //Constractor
        public Furniture(int width, int length, int height, double weight, bool isFragile, StorageStructure currentLocation, bool isModular) : base(width, length, height, weight, isFragile, currentLocation)
        {
            this.isModular = isModular;
        }
        //Method Example
        public void EasyDilivery()
        {
            if (isModular)
                Console.WriteLine("Your Furniture is compactable and easy to diliver!");
            else
                Console.WriteLine("Your Furniture is not compactable makes it harder to diliver!");
        }
    }
}
