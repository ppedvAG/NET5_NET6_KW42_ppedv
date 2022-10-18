using System;
using System.Collections.Generic;
using System.Linq;

namespace Modul11Demo_DictionaryUseCase
{
    internal class Program
    {
        static IDictionary<Guid, Club> allAvailable = new Dictionary<Guid, Club>();

        static IDictionary<Guid, Club> championsLeagueTeilnehmer = new Dictionary<Guid, Club>();
        static void Main(string[] args)
        {
            if (allAvailable.Count == 0)
            {
                allAvailable.Add(Guid.NewGuid(), new Club("Hannover 96"));
                allAvailable.Add(Guid.NewGuid(), new Club("BVB"));
                allAvailable.Add(Guid.NewGuid(), new Club("1860"));
                allAvailable.Add(Guid.NewGuid(), new Club("FCB"));
                allAvailable.Add(Guid.NewGuid(), new Club("KSC"));
                allAvailable.Add(Guid.NewGuid(), new Club("SGE"));
                allAvailable.Add(Guid.NewGuid(), new Club("MSV"));
                allAvailable.Add(Guid.NewGuid(), new Club("Schalke 04"));
                allAvailable.Add(Guid.NewGuid(), new Club("1 FCN"));
                allAvailable.Add(Guid.NewGuid(), new Club("BSC"));
                allAvailable.Add(Guid.NewGuid(), new Club("Union Berlin"));

                var orderdList = allAvailable.OrderBy(t => t.Value.Name);
            }


            ChampionsLeagueTeilneherDerBundesligar();


        }

        static void ChampionsLeagueTeilneherDerBundesligar()
        {
            bool exit = true;
            while (exit)
            {
                Console.Clear();
                Console.WriteLine("Alle Verfügbaren Fussballclubs ohne Champions-League Zuordnung");
                for (int i = 0; i < allAvailable.Count; i++)
                {
                    KeyValuePair<Guid, Club> currentClub = allAvailable.ElementAt(i);
                    if (!championsLeagueTeilnehmer.ContainsKey(currentClub.Key))
                    {
                        Console.WriteLine($"{i}.) {currentClub.Value.Name}");
                    }
                }


                Console.WriteLine("--------------------------------------------------------");

                Console.WriteLine("Qualifizierte Champions League Clubs");

                for (int i = 0; i < championsLeagueTeilnehmer.Count; i++)
                {
                    KeyValuePair<Guid, Club> currentClub = championsLeagueTeilnehmer.ElementAt(i);


                    Console.WriteLine($"{i}.) {currentClub.Value.Name}");
                }

                Console.WriteLine("--------------------------------------------------------");

                Console.Write("Wollen Sie in die Champions-League Lsite ein Team (1) hinzufügen | (2) löschen | (3) Exit> ");
                ConsoleKeyInfo keyInfoMenue = Console.ReadKey();
                Console.WriteLine();

                if (keyInfoMenue.Key == ConsoleKey.D1)
                {
                    Console.Write("Welches Team alle Verfügbaren Clubs soll in die Championsleague-Liste >");

                    ConsoleKeyInfo teamSelection = Console.ReadKey();

                    int index = Convert.ToInt32(teamSelection.KeyChar.ToString());

                    KeyValuePair<Guid, Club> selectedClub = allAvailable.ElementAt(index);
                    allAvailable.Remove(selectedClub.Key);

                    championsLeagueTeilnehmer.Add(selectedClub);
                }
                else if (keyInfoMenue.Key == ConsoleKey.D2 && championsLeagueTeilnehmer.Count > 0)
                {

                    Console.Write("Welches Team soll aus der Championsleague-Liste >");

                    ConsoleKeyInfo teamSelection = Console.ReadKey();

                    int index = Convert.ToInt32(teamSelection.KeyChar.ToString());

                    KeyValuePair<Guid, Club> selectedClub = championsLeagueTeilnehmer.ElementAt(index);
                    championsLeagueTeilnehmer.Remove(selectedClub.Key);
                    
                    allAvailable.Add(selectedClub);
                }
                else if (keyInfoMenue.Key == ConsoleKey.D3)
                {
                    exit = false;
                }
            }
        }
    }

    public class Club
    {
        public Club(string clubName)
        {
            Name = clubName;    
        }

        public string Name { get; set; }
    }
}
