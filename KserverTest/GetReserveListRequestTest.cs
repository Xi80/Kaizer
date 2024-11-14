using KaizerCommanderApi;

namespace KserverTest;

[TestClass]
public class GetReserveListRequestTest
{
    /// <summary>
    /// 正しくリクエストのbyte配列を作成できることを確認
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        var expected = new byte[] {0x51,0x11,0x00,0x00};
        var r = new GetReserveListRequest();
        var a = r.ToByteArray();
        Assert.IsNotNull(a);
        CollectionAssert.AreEqual(expected, a);
    }

    /// <summary>
    /// IsValid()がTrueであることを確認(Requestなので常にTrueになるはず)
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        var r = new GetReserveListRequest();
        Assert.AreEqual(r.IsValid(), true);
    }
}