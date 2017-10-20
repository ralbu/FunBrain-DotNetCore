using System.Collections.Generic;
using System.Linq;
using FunBrainDomain;

namespace FunBrainInfrastructure
{
    public class GameInput
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public static IEnumerable<UserGame> ToUserGame(IEnumerable<GameInput> inputs)
        {
            return inputs.Select(input => new UserGame(input.Id, input.Number));
        }
    }
}