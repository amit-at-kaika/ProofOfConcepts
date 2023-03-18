namespace ProofOfConcepts.SecretManager.UnitTests;
using Microsoft.Extensions.Configuration;

public class UnitTestWithSecrets : IClassFixture<BaseTest>
{
    private readonly IConfiguration _config;

    public UnitTestWithSecrets(BaseTest baseTest)
    {
        _config = baseTest.Configuration;
    }

    [Fact]
    public void TestInitializationOfSecrets()
    {
        int keyOneValue = _config.GetValue<int>("KeyOne");
        bool keyTwoValue = _config.GetValue<bool>("KeyTwo");

        Assert.Equal(1, keyOneValue);
        Assert.True(keyTwoValue);
    }
}