using DataGame.Model;
using DataGame.Repos.Interfaces;
using System;
using System.Collections.Generic;

namespace DataGame.Repos
{
    public class GameRepos : IGameRepos
    {
        private List<BaseOption> OptionsListe;
        private List<Player> PlayersListe;

        public List<BaseOption> InitialiteOptions()
        {
            var Rock = new BaseOption("Rock",0);
            var Paper = new BaseOption("Paper",1);
            var Scissors = new BaseOption("Scissors",2);
            var Flamethrower = new BaseOption("Flamethrower",3);

            Rock.strongerOptions.Add(Paper);
            Paper.strongerOptions.Add(Scissors);
            Scissors.strongerOptions.Add(Rock);
            Flamethrower.strongerOptions.Add(Rock);
            Flamethrower.strongerOptions.Add(Scissors);

            OptionsListe = new List<BaseOption>()
            {
                Rock,Paper,Scissors,Flamethrower
            };

            return OptionsListe;
        }
        public List<Player> InitialitePlayers(bool onlyHumans, bool ramdomSelection)
        {
            PlayersListe = new List<Player>();

            if (onlyHumans && !ramdomSelection)
            {
                PlayersListe.Add(new Player() { Name = "Player1", IsComputerPlayer = false });
                PlayersListe.Add(new Player() { Name = "Player2", IsComputerPlayer = false });
            }
            else if (ramdomSelection)
            {
                PlayersListe.Add(new Player() { Name = "Player1", IsComputerPlayer = false });
                PlayersListe.Add(new Player() { Name = "Player2", IsComputerPlayer = true, RamdomSelection = true });                
            }
            else
            {
                PlayersListe.Add(new Player() { Name = "Player1", IsComputerPlayer = false });
                PlayersListe.Add(new Player() { Name = "Player2", IsComputerPlayer = true });
            }

            return PlayersListe;
        }
        public bool DetermineIfIAmAWinner(BaseOption playerOption, BaseOption enemyOption)
        {
            return playerOption.DetermineIfIAmAWinner(enemyOption);
        }
        public BaseOption GetComputerOption(int lastSelectedOption)
        {
            Random rnd = new Random();
            if (PlayersListe[1].RamdomSelection)
                return OptionsListe[rnd.Next(0, 4)];
            else
                return OptionsListe[lastSelectedOption].GetNextStrongerOption();
        }


    }
}
