using System;
using System.Collections.Generic;
using FunBrainDomain;
using FunBrainInfrastructure.Repositories;

namespace FunBrainInfrastructure
{
    public interface IGameService
    {
        RoundResult RunGame(int gameId, IEnumerable<UserInGame> userInGame);
        string StartGame(GameInput gameInput);
    }
}