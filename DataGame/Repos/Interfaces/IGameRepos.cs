using DataGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGame.Repos.Interfaces
{
    public interface IGameRepos
    {
        List<BaseOption> InitialiteOptions();
        List<Player> InitialitePlayers(bool onlyHumans, bool ramdomSelection);
        bool DetermineIfIAmAWinner(BaseOption playerOption, BaseOption enemyOption);
        BaseOption GetComputerOption(int lastSelectedOption);
    }
}
