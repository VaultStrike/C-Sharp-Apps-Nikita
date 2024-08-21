using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Final_Project
{
    public interface IPortable
    {
        public int GetId();
        public double[] GetSize();
        public double GetArea();
        public double GetVolume();
        public double GetWeight();
        public void Packageitem();
        public void UnPackage();
        public bool IsPackaged();
        public bool IsFragile();
        public bool IsLoaded();
        public void LoadItem();
        public void UnLoadItem();
        public StorageStructure GetLocation();
        public void SetLocation(StorageStructure location);

    }
}
