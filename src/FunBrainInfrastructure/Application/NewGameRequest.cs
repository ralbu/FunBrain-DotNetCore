using System.Collections.Generic;
using FunBrainDomain;

namespace FunBrainInfrastructure.Application
{
    public class NewGameRequest
    {
        public int NoOfRounds { get; set; }
        public int MaxGuessNo { get; set; }
        public IEnumerable<int> UsersInGame { get; set; }


        public static IEnumerable<UserInGame> ToUserGame(IEnumerable<NewGameRequest> inputs)
        {
            return null;
//            return inputs.Select(input => new UserInGame(input.UserId, input.Number));
        }
    }
}