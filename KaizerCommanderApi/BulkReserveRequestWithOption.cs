namespace KaizerCommanderApi;

public class BulkReserveRequestWithOption : KserverCommandRequest
{
    public const int SizeExceptHeaderAndOption = 0x30;
    private int _optionCount;
    private int _requestSizeWithoutHeader;
    private string _tabletSerialNo;
    private int _entryType;
    private int _additionalInfo;
    private int _corelationNo;
    private long _localId;
    private long _songNo;
    private int _telopType;
    private int _reserve1;
    private int _contentsType;
    private long _contentsFileNo;
    private char[]? _entryNo = new char[11];
    private int _reserve2;
    private List<BulkReserveOption> _optionList = new();

    public BulkReserveRequestWithOption(int optionCount)
    {
        this._optionCount = optionCount;
        this._requestSizeWithoutHeader = 4 * this._optionCount + SizeExceptHeaderAndOption;
        this.Header = new KserverHeader(0x5110, (ushort)this._requestSizeWithoutHeader);
        SetTabletSerialNo(Utils.GetSelfSerialNo());
    }
    
    public override byte[]? ToByteArray() {
        if (!IsValid()) {
            return null;
        }

        MemoryStream stream = new();
        SetHeaderValueToMemoryStream(stream);
        KserverCommandRequest.SetSelfSerialNoToMemoryStream(this._tabletSerialNo, stream);
        stream.WriteByte((byte)_entryType);
        stream.WriteByte((byte)_additionalInfo);
        stream.WriteUInt16B((ushort)_corelationNo);
        stream.WriteUInt32B((uint)_localId);
        stream.WriteUInt32B((uint)_songNo);
        stream.WriteByte((byte)_telopType);
        stream.WriteByte((byte)_reserve1);
        stream.WriteUInt16B((ushort)_contentsType);
        stream.WriteUInt32B((uint)_contentsFileNo);
        
        foreach (var c in _entryNo)
        {
            stream.WriteByte((byte)c);
        }

        foreach (var o in _optionList)
        {
            stream.WriteUInt16B((ushort)o.GetOptionType());
            stream.WriteUInt16B((ushort)o.GetOptionValue());
        }
        return stream.ToArray();
    }
    
       public override bool IsValid() {
        if (this._entryNo == null) {
            Logger.Error("entry No = null");
            return false;
        }
        if (this._entryNo.Length != 0x11) {
            Logger.Error("Invalid entry No length: " + this._entryNo.Length);
            return false;
        }

        if (this._optionCount == this._optionList.Count) return true;
        
        Logger.Error($"Invalid option list size: Expected: {this._optionCount}, Actual: {this._optionList.Count}");
        return false;
       }

    public String GetTabletSerialNo() {
        return this._tabletSerialNo;
    }

    private void SetTabletSerialNo(String tabletSerialNo) {
        this._tabletSerialNo = tabletSerialNo;
    }

    public int GetEntryType() {
        return this._entryType;
    }

    public void SetEntryType(int entryType) {
        this._entryType = entryType;
    }

    public int GetAdditionalInfo() {
        return this._additionalInfo;
    }

    public void SetAdditionalInfo(int additionalInfo) {
        this._additionalInfo = additionalInfo;
    }

    public int GetCorelationNo() {
        return this._corelationNo;
    }

    public void SetCorelationNo(int corelationNo) {
        this._corelationNo = corelationNo;
    }

    public long GetLocalId() {
        return this._localId;
    }

    public void SetLocalId(long localId) {
        this._localId = localId;
    }

    public long GetSongNo() {
        return this._songNo;
    }

    public void SetSongNo(long songNo) {
        this._songNo = songNo;
    }

    public int GetTelopType() {
        return this._telopType;
    }

    public void SetTelopType(int telopType) {
        this._telopType = telopType;
    }

    public int GetReserve1() {
        return this._reserve1;
    }

    public void SetReserve1(int reserve1) {
        this._reserve1 = reserve1;
    }

    public int GetContentsType() {
        return this._contentsType;
    }

    public void SetContentsType(int contentsType) {
        this._contentsType = contentsType;
    }

    public long GetContentsFileNo() {
        return this._contentsFileNo;
    }

    public void SetContentsFileNo(long contentsFileNo) {
        this._contentsFileNo = contentsFileNo;
    }

    public char[] GetEntryNo() {
        return this._entryNo;
    }

    public void SetEntryNo(char[] entryNo) {
        this._entryNo = entryNo;
    }

    public int GetReserve2() {
        return this._reserve2;
    }

    public void SetReserve2(int reserve2) {
        this._reserve2 = reserve2;
    }

    public int GetOptionCount() {
        return this._optionCount;
    }

    public void SetOption(int type, int value) {
        this._optionList.Add(new BulkReserveOption(type, value));
    }

    public void SetOption(BulkReserveOption option) {
        this._optionList.Add(option);
    }

}

public class BulkReserveOption(int optionType, int optionValue)
{
    public const int BulkReserveOptionSize = 0x04;
    private int _optionType = optionType;
    private int _optionValue = optionValue;
    
    public int GetOptionType() {
        return this._optionType;
    }

    public void SetOptionType(int optionType) {
        this._optionType = optionType;
    }

    public int GetOptionValue() {
        return this._optionValue;
    }

    public void SetOptionValue(int optionValue) {
        this._optionValue = optionValue;
    }

}