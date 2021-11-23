using System.Collections.Generic;

namespace DataGame.Model
{
    public class BaseOption
    {
        public string Name { get; set; }
        public int IdOption { get; set; }
        public BaseOption(string name, int idOption)
        {
            Name = name;
            IdOption = idOption;
        }

        public List<BaseOption> strongerOptions = new List<BaseOption>();

        public bool DetermineIfIAmAWinner(BaseOption attackingOption)
        {
            return !strongerOptions.Exists(x => x.Name.Equals(attackingOption.Name));
        }

        public BaseOption GetNextStrongerOption()
        {
            return strongerOptions[0];
        }
    }
}
