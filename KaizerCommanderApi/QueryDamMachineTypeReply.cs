namespace KaizerCommanderApi;

public class QueryDamMachineTypeReply : KserverCommandReply
{
    public const int SizeExceptHeader = 0x24;
    private long _protocolVersion;
    private string _machineTypeId;
    private string _machineTypeSubId;
    private string _damSerialNo;
    private string _sysBinVersion;
    private int _bbServiceIndicator;
    private int _reserve1;
    private string _printerVersion;
    private long _reserve2;

    public override void SetValueFromMemoryStream(MemoryStream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);
        Header = KserverHeader.GenerateHeaderFromMemoryStream(stream);
        _protocolVersion = stream.ReadUInt32B();
        _machineTypeId = stream.ReadString(2);
        _machineTypeSubId = stream.ReadString(2);
        _damSerialNo = stream.ReadString(8);
        _sysBinVersion = stream.ReadString(8);
        _bbServiceIndicator = stream.ReadUInt16B();
        _reserve1 = stream.ReadUInt16B();
        _printerVersion = stream.ReadString(4);
        _reserve2 = stream.ReadUInt32B();
    }
    
    public long GetProtocolVersion() {
        return this._protocolVersion;
    }

    public void SetProtocolVersion(long protocolVersion) {
        this._protocolVersion = protocolVersion;
    }

    public String GetMachineTypeId() {
        return this._machineTypeId;
    }

    public void SetMachineTypeId(String machineId) {
        this._machineTypeId = machineId;
    }

    public String GetMachineTypeSubId() {
        return this._machineTypeSubId;
    }

    public void SetMachineTypeSubId(String machineSubId) {
        this._machineTypeSubId = machineSubId;
    }

    public String GetDamSerialNo() {
        return this._damSerialNo;
    }

    public void SetDamSerialNo(String damSerialNo) {
        this._damSerialNo = damSerialNo;
    }

    public String GetSysBinVersion() {
        return this._sysBinVersion;
    }

    public void SetSysBinVersion(String sysBinVersion) {
        this._sysBinVersion = sysBinVersion;
    }

    public int GetBbServiceIndicator() {
        return this._bbServiceIndicator;
    }

    public void SetBbServiceIndicator(int bbServiceIndicator) {
        this._bbServiceIndicator = bbServiceIndicator;
    }

    public int GetReserve1() {
        return this._reserve1;
    }

    public void SetReserve1(int reserve1) {
        this._reserve1 = reserve1;
    }

    public String GetPrinterVersion() {
        return this._printerVersion;
    }

    public void SetPrinterVersion(String printerVersion) {
        this._printerVersion = printerVersion;
    }

    public long GetReserve2() {
        return this._reserve2;
    }

    public void SetReserve2(int reserve2) {
        this._reserve2 = reserve2;
    }

}