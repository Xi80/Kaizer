namespace KaizerCommanderApi;

/// <summary>
/// 予約リスト取得リクエスト
/// </summary>
public class GetReserveListRequest : KserverCommandRequest
{
    public const ushort SizeExceptHeader = 0;

    public GetReserveListRequest()
    {
        this.Header = new(0x5111, 0);
    }

    public override byte[]? ToByteArray()
    {
        if (!IsValid())
        {
            Logger.Error("IsValid() is false");
            return null;
        } 
        MemoryStream ms = new();
        SetHeaderValueToMemoryStream(ms);
        return ms.ToArray();
    }

    public override bool IsValid()
    {
        return true;
    }
}