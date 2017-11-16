using System;
using System.Collections.Generic;
using FunBrainDomain;
using FunBrainInfrastructure.Application;
using FunBrainInfrastructure.Repositories;

namespace FunBrainInfrastructure
{
    // TODO: Do I need the interface?
    public interface IGameService
    {
        RoundResult RunGame(Guid gameId, IEnumerable<UserInGame> userInGame);
        string Create(NewGameRequest command);
    }
}