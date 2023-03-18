namespace ProofOfConcepts.SecretManager.UnitTests;
using Microsoft.Extensions.Configuration;

public class BaseTest
{
    public BaseTest()
    {
        Configuration = new ConfigurationBuilder()
            .AddUserSecrets("20f50b9d-4fe1-45e8-841e-ed83080edc44") 
            .Build();
    }

    public IConfiguration Configuration { get; }
}