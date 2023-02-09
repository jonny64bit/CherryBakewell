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

        //This method isn't needed in the end but keep it here any way to give us something else to talk about.
        public async Task<List<Calculation>> GetLast(int amount = 5)
        {
            const string sql = "SELECT TOP (@Amount) * FROM Calculations ORDER BY Order DESC";
            using (var connection = new SqlConnection(Context.Database.GetConnectionString()))
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<Calculation>(sql, new { Amount = amount })).AsList();
            }
        }
    }
}
