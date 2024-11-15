using KaizerCommanderApi;

namespace KserverTest;
[TestClass]
public class QueryDamMachineTypeReplyTest
{
  [TestMethod]
  public void TestMethod1()
  {
    var ms = new MemoryStream(new byte[]{0x80, 0x32, 0x0, 0x24, 0x0, 0x0, 0x0, 0x20, 0x31, 0x37, 0x30, 0x30, 0x41, 0x46, 0x30, 0x32, 0x32, 0x37, 0x31, 0x32, 0x30, 0x30, 0x30, 0x30, 0x30, 0x33, 0x37, 0x37, 0x0, 0x1, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0});
    var r = new QueryDamMachineTypeReply();
    r.SetValueFromMemoryStream(ms);
    Assert.AreEqual(r.GetDamSerialNo(),"AF022712");
    Assert.AreEqual(r.GetBbServiceIndicator(),1);
  }
}