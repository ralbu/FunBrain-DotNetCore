using FunBrainDomain;
using FunBrainInfrastructure.Application;

namespace FunBrainInfrastructure.Repositories
{
    public interface IGameRepository
    {
        int CreateGame(NewGameRequest newGameRequest);
        Game GetGame(int gameId);
    }
}