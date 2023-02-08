using CherryBakewell.Base.Interfaces.Repository;
using CherryBakewell.Database;
using CherryBakewell.Database.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CherryBakewell.Base.Repositories
{
    public class CalculationRepository : ICalculationRepository
    {
        public CalculationRepository(DAL context)
        {
            Context = context;
        }

        public DAL Context { get; }

        public async Task AddAsync(Calculation calculation)
        {
            using (var connection = new SqlConnection(Context.Database.GetConnectionString()))
            {
                await connection.OpenAsync();
                await connection.InsertAsync(calculation);
            }
        }

        public async Task<List<Calculation>> GetLast(int amount = 5)
        {
            const string sql = "SELECT TOP (@Amount) * FROM Calculation ORDER BY Order DESC";
            using (var connection = new SqlConnection(Context.Database.GetConnectionString()))
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<Calculation>(sql, new { Amount = amount })).AsList();
            }
        }
    }
}
