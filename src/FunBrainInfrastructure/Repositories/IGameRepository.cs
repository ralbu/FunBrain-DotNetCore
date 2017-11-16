using System;
using FunBrainDomain;
using FunBrainInfrastructure.Application;

namespace FunBrainInfrastructure.Repositories
{
    public interface IGameRepository
    {
        int CreateGame(Game game);
        Game GetGame(Guid gameId);
    }
}