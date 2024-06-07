using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace C_Sharp_Apps_Nikita.Sport_App
{
    public class Sport_App_Main
    {
        public static void Test1()
        {

            Console.WriteLine("Test 1 - champions league mock");
            Season[] groups = CreateChampionsLeagueMock();

            //groups.DisplayTable();
            Console.WriteLine("");
            char ch = 'A';
            for (int i = 0; i < groups.Length; i++)
            {
                Console.WriteLine("Group: " + ch);
                groups[i].DisplayTable();
                Console.WriteLine("");
                ch++;
            }

        }
        public static Season[] CreateChampionsLeagueMock()
        {

            //your code come here

            //קבוצה 1
            Team bayern = new Team("Bayern", "Bayern");
            Team copenhagen = new Team("Copenhagen", "Copenhagen");
            Team galastray = new Team("Galastray", "Galastray");
            Team manUnited = new Team("Man United", "Manchester");

            //קבוצה 2
            Team arsenal = new Team("Arsenal", "London");
            Team psv = new Team("psv", "eindhoven");
            Team lens = new Team("Lens", "Lens");
            Team sevilla = new Team("Sevilla", "Sevilla");

            //קבוצה 3
            Team realMadrid = new Team ("Real Madrid", "madrid");
            Team napoli = new Team("Napoli","Napoli");
            Team braja = new Team("Braja", "Braja");
            Team unionBerlin = new Team("Union Berlin", "Berlin");

            //קבוצה 4
            Team realSociedad = new Team("Real Sociedad", "Sebastián");
            Team inter = new Team("Inter", "Milan");
            Team benfica = new Team("benfica", "lisbon");
            Team sazlburg = new Team("salzburg", "salzburg");

            //קבוצה 5
            Team atleteco = new Team("Atletico Madrid", "Madrid");
            Team lazio = new Team("Lazio", "Roma");
            Team feyenoord = new Team("Feyenoord", "Rotterdam");
            Team celtic = new Team("Celtic", "Glasgow");

            //קבוצה 6
            Team dortmund = new Team("Dortmund ", "Dortmund");
            Team psg = new Team("PSG ", "Paris");
            Team aCMilan = new Team("AC Milan ", "Milan");
            Team newCastle = new Team("NewCastle ", "United Kingdom");

            //קבוצה 7
            Team manchesterCity = new Team("Manchester City ", "Manchester");
            Team rbLeipzig = new Team("RB Leipzig", "leipzig");
            Team youngBoys = new Team("Young Boys", "Bern");
            Team crvana = new Team("Crvena zvezda", "Belgrad");

            //קבוצה 8
            Team barcelona = new Team("Barcelona", "Barcelona");
            Team porto = new Team("Porto", "Porto");
            Team shakhtarDonetsk = new Team("Shakhtar Donetsk", "Donetsk");
            Team antwerpFc = new Team("AntwerpFc", "Antwerp");

            //מערך של קבוצות לפי קבוצה
            Team[] groupA= {bayern,copenhagen, galastray, manUnited };
            Team[] groupB= { arsenal, psv, lens, sevilla };
            Team[] groupC = { realMadrid, napoli, braja, unionBerlin };
            Team[] groupD = { realSociedad, inter, benfica, sazlburg };
            Team[] groupE = { atleteco, lazio, feyenoord, celtic };
            Team[] groupF = { dortmund, psg, aCMilan, newCastle };
            Team[] groupG = { manchesterCity, rbLeipzig, youngBoys, crvana };
            Team[] groupH = { barcelona, porto, shakhtarDonetsk, antwerpFc };

            //בניה של הקבוצות בליגה
            Season GroupA = new Season("2024", "soccer", "Champoins - Group A", groupA);
            Season GroupB = new Season("2024","soccer", "Champoins - Group B", groupB);
            Season GroupC = new Season("2024","soccer", "Champoins - Group C", groupC);
            Season GroupD = new Season("2024","soccer", "Champoins - Group D", groupD);
            Season GroupE = new Season("2024","soccer", "Champoins - Group E", groupE);
            Season GroupF = new Season("2024","soccer", "Champoins - Group F", groupF);
            Season GroupG = new Season("2024","soccer", "Champoins - Group G", groupG);
            Season GroupH = new Season("2024","soccer", "Champoins - Group H", groupH);
            Season[] groups = {GroupA, GroupB, GroupC, GroupD, GroupE, GroupF, GroupG, GroupH };

            return groups;



        }
    }
}
