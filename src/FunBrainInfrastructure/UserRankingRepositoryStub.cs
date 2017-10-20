using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunBrainDomain;

namespace FunBrainInfrastructure
{
    public class UserRankingRepositoryStub: IUserRankingRepository
    {
        public IEnumerable<UserRanking> Get()
        {
            yield return new UserRanking
            {
                Id = 1,
                Name = "Ruslan",
                Ranking = 20
            };
        }

        public void UpdateWinner(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
