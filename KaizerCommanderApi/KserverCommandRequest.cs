using System.Text;

namespace KaizerCommanderApi;

public abstract class KserverCommandRequest
{
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    protected KserverHeader Header;
    
    public abstract bool IsValid();

    public abstract byte[] ToByteArray();

    public ushort GetMessageId()
    {
        return Header.GetMessageId();
    }

    public ushort GetDataSize()
    {
        return Header.GetDataSize();
    }

    public byte[] ConvertMemoryStreamToByteArray(MemoryStream stream)
    {
        var ret = new byte[stream.Length];
        stream.Seek(0, SeekOrigin.Begin);
        _ = stream.Read(ret, 0, (int)stream.Length);
        return ret;
    }

    public void SetHeaderValueToMemoryStream(MemoryStream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);
        stream.WriteUInt16B(Header.GetMessageId());
        stream.WriteUInt16B(Header.GetDataSize());
    }

    public static void SetSelfSerialNoToMemoryStream(string tabletSerialNo,MemoryStream stream)
    {
        if (tabletSerialNo.Length != 8)
        {
            Logger.Error($"tabletSerialNo is too small. Size: {tabletSerialNo.Length}");
            throw new ArgumentException($"tabletSerialNo is too small. Expected: {8:D}, Actual: {tabletSerialNo.Length:D}");
        }

        var tabletSerialNoBytes = Encoding.UTF8.GetBytes(tabletSerialNo);
        stream.Write(tabletSerialNoBytes, 0, tabletSerialNoBytes.Length);
    }
}