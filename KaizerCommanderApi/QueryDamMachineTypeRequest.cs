namespace KaizerCommanderApi;

public class QueryDamMachineTypeRequest : KserverCommandRequest
{
    public const int SizeExceptHeader = 0x08;
    private readonly string _tabletSerialNo;

    public QueryDamMachineTypeRequest()
    {
        this.Header = new KserverHeader(0x4032, 0x08);
        this._tabletSerialNo = Utils.GetSelfSerialNo();
    }
    
    public override byte[]? ToByteArray() {
        if (!IsValid()) {
            return null;
        }
        var stream = new MemoryStream();
        SetHeaderValueToMemoryStream(stream);
        KserverCommandRequest.SetSelfSerialNoToMemoryStream(this._tabletSerialNo, stream);
        return stream.ToArray();
    }
    public override bool IsValid() {
        return true;
    }

    public string GetTabletSerialNo() {
        return this._tabletSerialNo;
    }
}