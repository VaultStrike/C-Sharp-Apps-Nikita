using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Sport_App
{
    public class Game
    {
        private Team team1;
        private Team team2;
        private int goalsTeam1;
        private int goalsTeam2;
        private string currentTime;
        private bool isActive;

        public Game(Team team1, Team team2)
        {
            this.team1 = team1;
            this.team2 = team2;
            goalsTeam1 = 0;
            goalsTeam2 = 0;
            isActive= false;
            currentTime = "00:00";
        }
    }

}
