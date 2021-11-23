using Game.Model;
using Game.Repos.Interfaces;
using System;
using System.Collections.Generic;

namespace Game.Repos
{
    public class GameRepos : IGameRepos
    {
        private List<BaseOption> OptionsListe;
        private List<Player> PlayersListe;

        public List<BaseOption> InitialiteOptions()
        {
            var Rock = new BaseOption("Rock", 0);
            var Paper = new BaseOption("Paper", 1);
            var Scissors = new BaseOption("Scissors", 2);
            var Flamethrower = new BaseOption("Flamethrower", 3);

            Rock.strongerOptions.Add(Paper);
            Paper.strongerOptions.Add(Scissors);
            Paper.strongerOptions.Add(Flamethrower);
            Scissors.strongerOptions.Add(Rock);
            Flamethrower.strongerOptions.Add(Rock);
            Flamethrower.strongerOptions.Add(Scissors);

            OptionsListe = new List<BaseOption>()
            {
                Rock,Paper,Scissors,Flamethrower
            };

            return OptionsListe;
        }
        public List<Player> InitialitePlayers(bool onlyHumans, bool RandomSelection)
        {
            PlayersListe = new List<Player>();

            if (onlyHumans && !RandomSelection)
            {
                PlayersListe.Add(new Player() {IsComputerPlayer = false });
                PlayersListe.Add(new Player() {IsComputerPlayer = false });
            }
            else if (RandomSelection)
            {
                PlayersListe.Add(new Player() {IsComputerPlayer = false });
                PlayersListe.Add(new Player() {IsComputerPlayer = true, RandomSelection = true });
            }
            else
            {
                PlayersListe.Add(new Player() {IsComputerPlayer = false });
                PlayersListe.Add(new Player() {IsComputerPlayer = true });
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
            if (PlayersListe[1].RandomSelection)
                return OptionsListe[rnd.Next(0, 4)];
            else
                return OptionsListe[lastSelectedOption].GetNextStrongerOption();
        }


    }
}
