using KaizerCommanderApi;

namespace KserverTest;

[TestClass]
public class KserverHeaderTest
{
    private ArgumentException   _ex = new ArgumentException();

    /// <summary>
    /// ヘッダのデータサイズが不足していた場合例外がスローされることを確認
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        var ms = new MemoryStream(new byte[]{0xDE,0xAD,0xBE});
        ms.Seek(0, SeekOrigin.Begin);
        _ex = Assert.ThrowsException<ArgumentException>(()=> KserverHeader.GenerateHeaderFromMemoryStream(ms));
        Assert.AreEqual($"Stream is too small. Expected: {KserverHeader.Size:D}, Actual: {ms.Length:D}", _ex.Message);
    }
    
    /// <summary>
    /// コンストラクタで指定したmessageIdとdataSizeが正しく取り出せることを確認
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        const ushort messageId = 0xDEAD;
        const ushort dataSize = 0xBEEF;
        var h = new KserverHeader(messageId,dataSize);
        Assert.AreEqual(h.GetMessageId(), messageId);
        Assert.AreEqual(h.GetDataSize(), dataSize);
    }

    /// <summary>
    /// ヘッダをMemoryStreamから正しく取り出せることを確認
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        const ushort messageId = 0xDEAD;
        const ushort dataSize = 0xBEEF;
        var ms = new MemoryStream();
        ms.WriteUInt16B(messageId);
        ms.WriteUInt16B(dataSize);
        ms.Seek(0, SeekOrigin.Begin);
        var h = KserverHeader.GenerateHeaderFromMemoryStream(ms);
        Assert.AreEqual(h.GetMessageId(), messageId);
        Assert.AreEqual(h.GetDataSize(), dataSize);
    }
}