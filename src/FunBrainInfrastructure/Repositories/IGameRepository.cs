using FunBrainDomain;

namespace FunBrainInfrastructure.Repositories
{
    public interface IGameRepository
    {
        int CreateGame(GameInput gameInput);
        Game GetGame(int gameId);
    }
}