using System;
using System.Collections.Generic;
using FunBrainDomain;
using FunBrainInfrastructure.Application;
using FunBrainInfrastructure.Repositories;

namespace FunBrainInfrastructure
{
    public interface IGameService
    {
        RoundResult RunGame(int gameId, IEnumerable<UserInGame> userInGame);
        string Create(NewGameRequest newGameRequest);
    }
}