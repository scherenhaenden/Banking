using BankingDataAccess_Tests.WeirdStuff;

namespace BankingDataAccess_Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        RPCServer.run();
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}