using ProofOfConcepts.CSToExcel;
namespace ProofOfConcepts.CSToExcel.UnitTests;

public class ClassSupplyingJsonUnitTests
{
    [Fact]
    public void Test_Initialization()
    {
        var obj = new ClassSupplyingJson();
        Assert.True(obj.Init(@"D:\Temp\sampleTextAsJson.json"));
    }
}