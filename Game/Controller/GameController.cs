using Game.Model;
using System;
using System.Collections.Generic;

namespace Game.Controller
{
    public class GameController
    {
        public List<BaseOption> OptionsListe;
        public List<Player> PlayersListe;
        public int Round;
        public int Player1Points;
        public int Player2Points;
        public int lastSelectedOption;

        public GameController()
        {
            Round = 0;
            Player1Points = 0;
            Player2Points = 0;
            lastSelectedOption = new Random().Next(0, 4);
        }

        public void InitializeGame(bool onlyHumans, bool RandomSelection)
        {
            OptionsListe = SingletonGame.Instance.InitialiteOptions();
            PlayersListe = SingletonGame.Instance.InitialitePlayers(onlyHumans, RandomSelection);
        }

        public bool IsWinner(int player1Selection, int player2Selection)
        {
            BaseOption optionSelectedPlayer1 = OptionsListe[player1Selection];
            BaseOption optionSelectedPlayer2 = OptionsListe[player2Selection];
            bool player1win = SingletonGame.Instance.DetermineIfIAmAWinner(optionSelectedPlayer1, optionSelectedPlayer2);
            UpdatePoints(player1win);
            return player1win;
        }

        public int GetComputerOption()
        {
            lastSelectedOption = SingletonGame.Instance.GetComputerOption(lastSelectedOption).IdOption;
            return lastSelectedOption;
        }

        public void UpdatePoints(bool player1win)
        {            
            if (player1win)
                Player1Points++;
            else
                Player2Points++;
            Round++;
        }
    }
}


