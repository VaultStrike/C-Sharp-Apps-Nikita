using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Sport_App.GeneralPlayer
{
    public class GeneralPlayer
    {
        //Properties
        protected int points;
        private string scoreName;// goal/basket לדוגמה
        private int assists;
        protected int fouls;
        protected bool outOfGame;

        //Constractor
        public GeneralPlayer(string scoreName)
        {
            this.scoreName = scoreName;
            this.points = 0;
            this.assists = 0;
            this.fouls = 0;
            this.outOfGame = false;
        }
        //Methods
        public virtual void ScoreField()
        {
          points++;
        }
        public virtual void AddFoul()
        {
            fouls++;
        }
        public virtual void DisplayScore()
        {
            Console.WriteLine($"You Scored Goal! \n Your Score:{points}");
        }

    }
}
