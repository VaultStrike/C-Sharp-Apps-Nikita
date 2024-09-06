using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.BankApp
{
    public class Owner
    {
        private string name;
        private string lastName;

        public Owner(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
        }
        public string GetFirstName() { return this.name; }
        public string GetLastName() { return this.lastName; }

    }
}
