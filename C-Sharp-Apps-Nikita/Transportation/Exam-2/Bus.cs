using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Exam_2
{
    public class Bus : PublicVehicle
    {
        //proparties
        private readonly int doors;
        private bool bellStop = false;

        //Getter & Setters
        public int Doors => doors;
        public bool BellStop { get => bellStop; set => bellStop = value; }
        public override int MaxSpeed
        {
            get => this.maxSpeed;
            set
            {
                if (value <= 120)
                    maxSpeed = value;
            }
        }
        //Constractor
        public Bus(int line, int id, int maxSpeed, int seats, int doors) : base(line, id, maxSpeed, seats)
        {
            this.doors = doors;
            if (this.maxSpeed > maxSpeed)
                this.maxSpeed = 120;
            else
                this.maxSpeed = maxSpeed;
        }
        public Bus() : base()
        {
            this.doors = 1;
        }
        //Methods
        public override bool CalculateHasRoom()
        {
            return (Math.Round(Seats * 1.1) - CurrentPassengers) > 0;
        }
        public override void UploadPassengers(int pass)
        {
            if (CalculateHasRoom())
            {
                int maxPassengers = (int)Math.Round(Seats * 1.1);
                int totalPassengers = CurrentPassengers + pass;

                if (totalPassengers <= maxPassengers)
                {
                    CurrentPassengers += pass;
                    HasRoom = totalPassengers < maxPassengers;
                    RejecetedPassengers = 0;
                }
                else
                {
                    RejecetedPassengers = totalPassengers - maxPassengers;
                    CurrentPassengers = maxPassengers;
                    HasRoom = false;
                }
            }
        }
        public override string ToString()
        {
            return $"{base.ToString} => SubClass Bus: Doors={doors} | BellStop={bellStop}";
        }




    }

}
