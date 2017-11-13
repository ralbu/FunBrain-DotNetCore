using System.Collections.Generic;
using System.Linq;
using FunBrainDomain;

namespace FunBrainInfrastructure
{
    public class GameInput
    {
        public int NoOfRounds { get; set; }
        public int MaxGuessNo { get; set; }
        public IEnumerable<int> UsersInGame { get; set; }

        public static IEnumerable<UserGame> ToUserGame(IEnumerable<GameInput> inputs)
        {
            return null;
//            return inputs.Select(input => new UserGame(input.Id, input.Number));
        }
    }
}