using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Final_Project
{
    public abstract class Item : IPortable
    {
        //Proparties
        private int id;
        private int width;
        private int length;
        private int height;
        private double weight;
        private bool isFragile;
        private bool isPackaged;
        private bool isLoaded;
        private StorageStructure currentLocation;
        //Getters/Setters
        public StorageStructure CurrentLocation { get => currentLocation; set => currentLocation = value; }
        public int Id { get => id; set => id = value; }

        //Constractors
        public Item() { }//Empty
        public Item( int width, int length, int height, double weight, bool isFragile, StorageStructure currentLocation)
        {
            this.width = width;
            this.length = length;
            this.height = height;
            this.weight = weight;
            this.isFragile = isFragile;
            isPackaged = false;
            isLoaded = false;
            this.currentLocation = currentLocation;
            id = new Random().Next(1000, 10000);
        }
        //Methods and Getters/Setters
        public void SetLocation(StorageStructure location)
        {
            this.currentLocation = location;
        }
        public double[] GetSize()
        {

            return new double[] { this.width, this.length, this.height };
        }
        public double GetArea()
        {
            return this.width * this.length;
        }
        public double GetVolume()
        {
            return this.width * this.length * this.height;
        }
        public double GetWeight()
        {
            return this.weight;
        }
        public void Packageitem()
        {
            this.isPackaged = true;
        }
        public void UnPackage()
        {
            this.isPackaged = false;
        }
        public void LoadItem()
        {
            this.isLoaded = true;
        }
        public void UnLoadItem()
        {
            this.isLoaded = false;
        }
        public bool IsPackaged()
        {
            return isPackaged;
        }
        public bool IsFragile()
        {
            return isFragile;
        }
        public bool IsLoaded()
        {
            return this.isLoaded;
        }
        public StorageStructure GetLocation()
        {
            return this.currentLocation;
        }

        public int GetId()
        {
            return id;
        }
        public override string ToString()
        {
            return $"Item ID: {id} | Volume: {GetVolume()} | Weight: {weight} | isFragile: {isFragile} | isPackaged: {isPackaged} | isLoaded: {isLoaded} | currentLocation -> {currentLocation.GetCity()} ";
        }


    }
}
