using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Sport_App
{
    public class Season
    {
        private string year;
        private string sportType;
        private string leagueType;
        private int rounds_Amount;
        private string next_Rounds;
        private Team[] team = new Team[4];
        private int teamIndex = 0;
        private int numberOfTeam;
        private bool isActive;

        public Season(string year, string sportType, string leagueType,int rounds_Amount,string next_Rounds,int numberOfTeam,bool isActive)
        {
            this.year = year;
            this.sportType = sportType;
            this.leagueType = leagueType;
            this.rounds_Amount = rounds_Amount;
            this.next_Rounds= next_Rounds;
            this.numberOfTeam = numberOfTeam;
            this.isActive = isActive;

        }
        public Season(string year, string SportType, string league, Team[] team)
        {
            this.year = year;
            this.sportType = SportType;
            this.leagueType = league;
            this.team = team;
        }
        public void SetTeam(Team team)
        {
            this.team[this.teamIndex] = team;
            this.teamIndex++;
        }
        public void DisplayTable()
        {

            for(int i = 0; i < this.team.Length; i++)
            {
                Console.WriteLine($"Team {i+1}: {this.team[i].GetName()} Points: {this.team[i].GetPoints()}");

            }


        }
        
    }
}
