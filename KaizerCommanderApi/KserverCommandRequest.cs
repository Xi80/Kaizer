using System.Text;

namespace KaizerCommanderApi;

public abstract class KserverCommandRequest
{
    private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

    public const int SerialLength = 8;
    
    protected KserverHeader header;
    
    public abstract bool IsValid();

    public abstract byte[] ToByteArray();

    public ushort GetMessageId()
    {
        return header.GetMessageId();
    }

    public ushort GetDataSzie()
    {
        return header.GetDataSize();
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
        stream.WriteUInt16B(header.GetMessageId());
        stream.WriteUInt16B(header.GetDataSize());
    }

    public static void SetSelfSerialNoToMemoryStream(string tabletSerialNo,MemoryStream stream)
    {
        if (tabletSerialNo.Length != SerialLength)
        {
            _logger.Error($"tabletSerialNo is too small. Size: {tabletSerialNo.Length}");
            throw new ArgumentException($"tabletSerialNo is too small. Expected: {SerialLength:D}, Actual: {tabletSerialNo.Length:D}");
        }

        var tabletSerialNoBytes = Encoding.UTF8.GetBytes(tabletSerialNo);
        stream.Write(tabletSerialNoBytes, 0, tabletSerialNoBytes.Length);
    }
}