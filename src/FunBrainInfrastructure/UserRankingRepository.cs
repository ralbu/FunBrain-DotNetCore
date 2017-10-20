using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using FunBrainDomain;

namespace FunBrainInfrastructure
{
    public class UserRankingRepository : IUserRankingRepository
    {
        private IDbConnection Connection
        {
            get
            {
                var cnString =
                    @"Data Source=localhost;Initial Catalog=FunBrain;Integrated Security=False;User Id=sa;Password=as;MultipleActiveResultSets=True";
                //var cnString = @"Server=localhost;Database=FunBrain;Trusted_Connection=true;";
                IDbConnection connection = new SqlConnection(cnString);

                return connection;
            }
        }

        public IEnumerable<UserRanking> Get()
        {
            IEnumerable<UserRanking> userRankings;
            using (IDbConnection cn = Connection)
            {
                string query = "SELECT * from UserRanking";
                cn.Open();

                userRankings = cn.Query<UserRanking>(query);
            }

            return userRankings;
        }

        public void UpdateWinner(int userId)
        {
            var sqlUpdate = @"
                UPDATE UserRanking
                SET Ranking = (SELECT Ranking WHERE Id = @userId) + 1
                WHERE Id = @userId 
               ";
            using (var cn = Connection)
            {
                cn.Execute(sqlUpdate, new {userId});
            }
        }
    }
}