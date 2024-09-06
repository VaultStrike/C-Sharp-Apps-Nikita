using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Exam_2
{
    public class PassengersTrain : PublicVehicle
    {
        private Crone[] crones = null;
        private int cronesAmount = 0;

        public Crone[] Crones { get => crones; set => crones = value; }

        public PassengersTrain(int line, int id, int maxSpeed, Crone crone, int cronesAmount) : base(line, id, maxSpeed, 0)
        {
            this.crones = new Crone[cronesAmount];
            this.cronesAmount = cronesAmount;
            for (int i = 0; i < crones.Length; i++)
            {
                crones[i] = new Crone(crone);
            }
        }

        public override bool CalculateHasRoom()
        {
            int totalSeats = 0;
            for (int i = 0; i < crones.Length; i++)
            {
                totalSeats += crones[i].GetSeats() + crones[i].GetExtras();
            }
            return (totalSeats - CurrentPassengers) > 0;
        }

        public override void UploadPassengers(int passengers)
        {
            if (!CalculateHasRoom())
            {
                Console.WriteLine("No, the train is full");
                return;
            }

            int totalSeats = 0;
            for (int i = 0; i < crones.Length; i++)
            {
                totalSeats += crones[i].GetSeats() + crones[i].GetExtras();
            }

            int availableSeats = totalSeats - CurrentPassengers;

            if (availableSeats >= passengers)
            {
                CurrentPassengers += passengers;
                if (CurrentPassengers == totalSeats)
                {
                    HasRoom = false;
                }
            }
            else
            {
                RejecetedPassengers = passengers - availableSeats;
                CurrentPassengers = totalSeats;
                HasRoom = false;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} => SubClass PassengersTrain:  CronesAmount={cronesAmount}";
        }
    }
}
