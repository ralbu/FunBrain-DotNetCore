using System;
using System.Collections.Generic;
using System.Text;
using FunBrainDomain;

namespace FunBrainInfrastructure
{
    public class UserRankingRepositoryInMemory: IUserRankingRepository
    {
        public IEnumerable<UserRanking> Get()
        {
            yield return new UserRanking
            {
                Id = 1,
                Name = "User 1",
                Ranking = 20
            };
            yield return new UserRanking
            {
                Id = 2,
                Name = "User 2",
                Ranking = 30
            };
        }

        public void UpdateWinner(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
