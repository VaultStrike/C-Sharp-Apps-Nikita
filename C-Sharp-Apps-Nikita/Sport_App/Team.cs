using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Sport_App
{
    public class Team
    {
        private string name;
        private string city;
        private string league_Current;
        private int sum_Games;
        private int count_Games;
        private int winners;
        private int losing;
        private bool draw;
        private int points;
        private int goalsFor;
        private int goalAgainst;
        private int goalDifferential;

        public Team(string name, string city)
        {
            this.name = name;
            this.city = city;
        }
        public string GetName() { return name; }
        public int GetPoints() { return points; }
        public void SetName(string name) { this.name = name;}
        public void SetPoints(int points) { this.points = points;}

    }
}
