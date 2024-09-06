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
        private int goalTeam1;
        private int goalTeam2;
        private string currentTime;
        private bool gameIsActive;

        public Game(Team team1, Team team2)
        {
            this.team1 = team1;
            this.team2 = team2;
            goalTeam1 = 0;
            goalTeam2 = 0;
            gameIsActive = false;
            currentTime = "00:00";
        }
        public void ScoreGoal(Team team)
        {
            if (this.gameIsActive)
            {
                if (team == this.team1)
                {
                    this.goalTeam1++;
                }
                else if (team == this.team2)
                {
                    this.goalTeam2++;
                }
                Console.WriteLine($"{team.GetName()} scored a goal!");
            }
            else
            {
                Console.WriteLine("The game has already finished. No more goals can be scored.");
            }
        }

        public void FinishGame()
        {
            this.gameIsActive = false;

            Console.WriteLine($"The game has ended. Final scores:");
            Console.WriteLine($"{team1.GetName()}: {goalTeam1}");
            Console.WriteLine($"{team2.GetName()}: {goalTeam2}");

            if (this.goalTeam1 > this.goalTeam2)
            {
                Console.WriteLine($"The winner is {team1.GetName()}");
                team1.SetPoints(3);
                team2.SetPoints(0);
            }
            else if (this.goalTeam2 > this.goalTeam1)
            {
                Console.WriteLine($"The winner is {team2.GetName()}");
                team1.SetPoints(0);
                team2.SetPoints(3);
            }
            else
            {
                Console.WriteLine("The game ended in a draw.");
                team1.SetPoints(1);
                team2.SetPoints(1);
            }
        }
    }

}
