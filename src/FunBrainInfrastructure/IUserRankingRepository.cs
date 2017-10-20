using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunBrainDomain;

namespace FunBrainInfrastructure
{
    public interface IUserRankingRepository
    {
        IEnumerable<UserRanking> Get();
        void UpdateWinner(int userId);
    }
}
