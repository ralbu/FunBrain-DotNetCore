using System;
using System.Collections.Generic;
using FunBrainInfrastructure.Repositories;

namespace FunBrainInfrastructure
{
    public interface IGameService
    {
        GameResultViewModel RunGame(Guid gameId, IEnumerable<UserInGame> userInGame);
        string StartGame(GameInput gameInput);
    }
}