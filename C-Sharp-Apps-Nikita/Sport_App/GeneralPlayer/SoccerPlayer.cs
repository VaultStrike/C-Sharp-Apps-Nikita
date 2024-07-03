using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Sport_App.GeneralPlayer
{
    public class SoccerPlayer : GeneralPlayer
    {
        //Properties
        private bool redCard;
        private int penalties;
        private int dribblingRate;
        //Constractor
        public SoccerPlayer(string scoreName) : base("Goal")
        {
            this.redCard= false;
            this.penalties= 0;          
        }
        //Methods
        public void SetRedCard() { this.redCard= true; }







    }

}
