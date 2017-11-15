using System.Collections.Generic;
using FunBrainDomain;

namespace FunBrainInfrastructure.Application
{
    public class NewGameRequest
    {
        public int NoOfRounds { get; set; }
        public int MaxGuessNo { get; set; }
        public IEnumerable<int> UsersInGame { get; set; }


        public static IEnumerable<UserGame> ToUserGame(IEnumerable<NewGameRequest> inputs)
        {
            return null;
//            return inputs.Select(input => new UserGame(input.Id, input.Number));
        }
    }
}