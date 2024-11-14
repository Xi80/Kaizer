namespace KaizerCommanderApi;

public class KserverHeader
{
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
    
    public const ushort Size = 4;
    private readonly ushort _dataSize;
    private readonly ushort _messageId;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id">メッセージID(16bit,BE)</param>
    /// <param name="size">メッセージ長さ(16bit,BE)</param>
    public KserverHeader(ushort id, ushort size)
    {
        _messageId = id;
        _dataSize = size;
        Logger.Debug($"ID = {_messageId:x4}, size = {_dataSize:x4}");
    }

    /// <summary>
    /// messageIdを取得
    /// </summary>
    /// <returns>messageId</returns>
    public ushort GetMessageId()
    {
        return _messageId;
    }

    /// <summary>
    /// dataSizeを取得
    /// </summary>
    /// <returns>dataSize</returns>
    public ushort GetDataSize()
    {
        return _dataSize;
    }

    /// <summary>
    /// MemoryStreamからKserverHeaderを作成
    /// </summary>
    /// <param name="stream">MemoryStream(事前に先頭にSeekしておく)</param>
    /// <returns>生成されたKserverHeader</returns>
    public static KserverHeader GenerateHeaderFromMemoryStream(MemoryStream stream)
    {
        if (stream.Length < Size)
        {
            Logger.Error($"Stream is too small. Size: {stream.Length}");
            throw new ArgumentException($"Stream is too small. Expected: {Size:D}, Actual: {stream.Length:D}");
        }
        var messageId = stream.ReadUInt16B();
        var size = stream.ReadUInt16B();
        return new KserverHeader(messageId, size);
    }
}