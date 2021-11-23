using Game.Model;
using System.Collections.Generic;
namespace Game.Repos.Interfaces
{
    public interface IGameRepos
    {
        List<BaseOption> InitialiteOptions();
        List<Player> InitialitePlayers(bool onlyHumans, bool RandomSelection);
        bool DetermineIfIAmAWinner(BaseOption playerOption, BaseOption enemyOption);
        BaseOption GetComputerOption(int lastSelectedOption);
    }
}
