using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Exam_2
{
    public class PublicVehicle
    {
        //Proparties
        private int line = 0;
        private int id = 0;
        protected int maxSpeed = 0;
        private int seats = 0;
        private int currentPassengers = 0;
        private int rejecetedPassengers = 0;
        private bool hasRoom = true;

        //Getter & Setters
        public int Line { get => line; set => line = value; }
        public int Id { get => id; set => id = value; }
        public int CurrentPassengers { get => currentPassengers; set => currentPassengers = value; }
        public int Seats { get => seats; set => seats = value; }
        public bool HasRoom { get => hasRoom; set => hasRoom = value; }
        public virtual int MaxSpeed
        {
            get => maxSpeed;
            set
            {
                if (value <= 40)
                    maxSpeed = value;

            }
        }

        public int RejecetedPassengers { get => rejecetedPassengers; set => rejecetedPassengers = value; }

        //Constractor
        public PublicVehicle()
        {

        }

        public PublicVehicle(int line, int id)
        {
            this.line = line;
            this.id = id;
        }

        public PublicVehicle(int line, int id, int maxSpeed, int seats)
        {
            this.line = line;
            this.id = id;
            this.Seats = seats;
            if (maxSpeed <= 40)
                this.maxSpeed = maxSpeed;
            else this.maxSpeed = 0;

        }
        //Methods
        public virtual bool CalculateHasRoom()
        {
            return (this.seats - this.currentPassengers) > 0;

        }

        public virtual void UploadPassengers(int SumOfPassengers)
        {
            if (!CalculateHasRoom())
            {
                return;
            }

            if (seats >= currentPassengers + SumOfPassengers)
            {
                currentPassengers += SumOfPassengers;
                if (currentPassengers == seats)
                {
                    HasRoom = false;
                }
            }
            else
            {
                rejecetedPassengers = (currentPassengers + SumOfPassengers) - seats;
                currentPassengers = seats;
                HasRoom = false;
            }
        }
        public override string ToString()
        {
            return $"Class: PublicVehicle | Line number: {line} | Current passengers {currentPassengers} | Rejeceted passengers: {rejecetedPassengers} | Has Room for more passengers: {hasRoom} ";
        }
    }
}
