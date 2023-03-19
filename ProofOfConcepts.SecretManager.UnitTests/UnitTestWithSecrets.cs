namespace ProofOfConcepts.SecretManager.UnitTests;
using Microsoft.Extensions.Configuration;

public class UnitTestWithSecrets : IClassFixture<BaseTest>
{
    private readonly IConfiguration _config;
    private readonly string _connectionString;

    public UnitTestWithSecrets(BaseTest baseTest)
    {
        _config = baseTest.Configuration;
        _connectionString = baseTest.ConnectionString;
    }

    [Fact]
    public void TestInitializationOfSecrets()
    {
        int keyOneValue = _config.GetValue<int>("KeyOne");
        bool keyTwoValue = _config.GetValue<bool>("KeyTwo");

        Assert.Equal(1, keyOneValue);
        Assert.True(keyTwoValue);
    }

    [Fact]
    public void TestInitializationOfConfigurationStr()
    {
        Assert.Equal("Server=localhost;User ID=User123;Password=pass123;Database=kaika", _connectionString);
    }
}