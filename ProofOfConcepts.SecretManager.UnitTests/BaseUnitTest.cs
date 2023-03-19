namespace ProofOfConcepts.SecretManager.UnitTests;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

public class BaseTest
{
    public BaseTest()
    {
        Configuration = new ConfigurationBuilder()
            .AddUserSecrets("20f50b9d-4fe1-45e8-841e-ed83080edc44")
            .AddJsonFile("appsettings.json") 
            .Build();

        var conStrBuilder = new MySqlConnectionStringBuilder(Configuration.GetConnectionString("Test")!);  
        conStrBuilder.UserID = Configuration.GetValue<string>("DbUser");
        conStrBuilder.Password = Configuration.GetValue<string>("DbPassword");
        ConnectionString = conStrBuilder.ConnectionString;
    }

    public IConfiguration Configuration { get; }
    public string ConnectionString { get; } 
    
}