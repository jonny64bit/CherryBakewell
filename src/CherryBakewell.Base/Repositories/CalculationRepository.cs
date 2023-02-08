using CherryBakewell.Base.Interfaces.Repository;
using CherryBakewell.Database;
using CherryBakewell.Database.Models;
using Dapper;
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
            const string sql = "INSERT INTO Calculation ([InputA], [InputB], [Operator], [Answer]) VALUES (@InputA, @InputB, @Operator, @Answer)";
            using (var connection = new SqlConnection(Context.Database.GetConnectionString()))
            {
                await connection.OpenAsync();
                await connection.ExecuteAsync(sql, 
                    new 
                    { 
                        calculation.InputA,
                        calculation.InputB,
                        calculation.Operator,
                        calculation.Answer
                    });
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
