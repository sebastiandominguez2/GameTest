using Game.Repos;
using Game.Repos.Interfaces;

namespace Game
{
    public sealed class SingletonGame
    {
        private static IGameRepos instance = null;
        private SingletonGame()
        {
        }
        public static IGameRepos Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameRepos();
                }
                return instance;
            }
        }
    }
}

