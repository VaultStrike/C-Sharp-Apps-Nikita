using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Sport_App.GeneralPlayer
{
    public class BasketBallPlayer : GeneralPlayer
    {
        //Properties
        private int dunks;
        private int threeShots;
        private int rebounds;

        //Constractor
        public BasketBallPlayer(string scoreName) : base("Basket")
        {
            dunks = 0;
            threeShots = 0;
            rebounds = 0;
        }
        //Methods
        public void Score3()
        {
            threeShots += 3;
        }
        public override void ScoreField()
        {
            this.points += 2;
            DisplayScore();
        }
        public override void AddFoul()
        {
            this.fouls++;
            if (this.fouls == 5)
            {
                this.outOfGame = true;
                Console.WriteLine("You Out Of Game!");
            }


        }

    }
}
