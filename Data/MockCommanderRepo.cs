using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>{
                new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="linux"},
                new Command{Id=1, HowTo="Cut a bread", Line="Cut bread", Platform="linux"},
                new Command{Id=2, HowTo="Make cup of tea", Line="Make tea", Platform="linux"},
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=id, HowTo="Boil an egg", Line="Boil water", Platform="linux"};
        }
    }
}