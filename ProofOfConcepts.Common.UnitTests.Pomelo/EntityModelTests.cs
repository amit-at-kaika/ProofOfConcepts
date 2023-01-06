using ProofOfConcept.Shared;

namespace ProofOfConcepts.Common.UnitTests.Pomelo;

public class EntityModelTests
{
    [Fact]
    public void DatabaseConnectTest()
    {
        using (SakilaContext db = new())
        {
            Assert.True(db.Database.CanConnect());
        }
    }
    [Fact]
    public void ActorCountTest()
    {
        using (SakilaContext db = new())
        {
            int expected = 200;
            int actual = db.Actors.Count();
            Assert.Equal(expected, actual);
        }
    }
    [Fact]
    public void CategoryCountTest()
    {
        using (SakilaContext db = new())
        {
            int expected = 16;
            int actual = db.Categories.Count();
            Assert.Equal(expected, actual);
        }
    }
}