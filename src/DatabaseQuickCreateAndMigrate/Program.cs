using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Database;
using PhoneBook.Database.Models;

//-----------------------------------------------
//This is just a quick and dirty method of fast prototyping entity framework schemas and migrations.
//-----------------------------------------------

//Set sql box location
const string host = "localhost";

//Set the database user account here
const string databaseName = "WeDoPhoneBook";
const string user = "WeDoPhoneBook";

// ReSharper disable once StringLiteralTypo
const string password = "Zl8089dAK5WJFNYD765IJD";

//Set sa password for sql box
const string passwordSa = "SqlServer2022";

await SetupDatabase();

var services = new ServiceCollection();
services.AddDbContext<DAL>(options =>
{
    options.EnableSensitiveDataLogging();
    options.UseSqlServer(
        $"Server={host};Database={databaseName};User Id={user};Password={password};MultipleActiveResultSets=True;;TrustServerCertificate=True");
});

var provider = services.BuildServiceProvider();
var context = provider.GetRequiredService<DAL>();
await context.Database.MigrateAsync();
await Seed(context);

static async Task SetupDatabase()
{
    using (var connection =
           new SqlConnection($"Server={host};User Id=sa;Password={passwordSa};MultipleActiveResultSets=True;TrustServerCertificate=True"))
    {
        var sb = new List<string>
        {
            "USE [master]",
            "sp_configure 'contained database authentication', 1;",
            "RECONFIGURE;",
            "ALTER DATABASE " + databaseName + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE",
            "DROP DATABASE IF EXISTS " + databaseName,
            "CREATE DATABASE " + databaseName,
            "ALTER DATABASE " + databaseName + " SET CONTAINMENT = PARTIAL",
            "USE " + databaseName,
            $"CREATE USER {user} WITH PASSWORD = '{password}'",
            "exec sp_addrolemember 'db_owner', '" + user + "';"
        };

        await connection.OpenAsync();
        foreach (var query in sb)
        {
            try
            {
                var command = new SqlCommand(query, connection);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}

static async Task Seed(DAL context)
{
    //Instead of seeding here you could do this in database migrations.
    //Really if its only data for testing/development i like to keep it out of migrations.
    await context.Contacts.AddRangeAsync(new List<Contact>
    {
        new()
        {
            FirstName = "Eric",
            LastName = "Elliot",
            PhoneNumber = "222-555-6754"
        },
        new()
        {
            FirstName = "Steve",
            LastName = "Jobs",
            PhoneNumber = "202-454-3245"
        }
    });

    await context.SaveChangesAsync();
}