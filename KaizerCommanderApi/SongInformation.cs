namespace KaizerCommanderApi;

public class SongInformation
{
    public const ushort Size = 0x18;
    private long _time = 0;      /* 予約した時点のUnixタイム? */
    private int _trayNo = 0;     /* 選曲番号上4桁*/
    private int _chapterNo = 0;  /* 選曲番号下2桁*/
    private int _sequenceNo = 0;
    private int _keyTempo = 0;
    private int _voiceChange = 0;
    private int _telopSongMask = 0;
    private int _guide = 0;
    private int _yourStory = 0;
    private int _localId = 0;
    private int _contentsType = 0;
    private long _backgroundMovie = 0;
    private int _dmtVocal = 0;
    private byte[] _reserve = new byte[3];

    public void SetValueFromMemoryStream(MemoryStream stream)
    {
        _time = stream.ReadUInt32B();
        _trayNo = stream.ReadUInt16B();
        _chapterNo = stream.ReadByte();
        _sequenceNo = stream.ReadByte();
        _keyTempo = stream.ReadByte();
        _voiceChange = stream.ReadByte();
        _telopSongMask = stream.ReadByte();
        _guide = stream.ReadByte();
        _yourStory = stream.ReadByte();
        _localId = stream.ReadByte();
        _contentsType = stream.ReadUInt16B();
        _backgroundMovie = stream.ReadUInt32B();
        _dmtVocal = stream.ReadByte();
        _ = stream.Read(_reserve, 0, _reserve.Length);
    }
    
    public long GetTime() {
        return this._time;
    }

    public void SetTime(long time) {
        this._time = time;
    }

    public int GetTrayNo() {
        return this._trayNo;
    }

    public void SetTrayNo(int trayNo) {
        this._trayNo = trayNo;
    }

    public int GetChapterNo() {
        return this._chapterNo;
    }

    public void SetChapterNo(int chapterNo) {
        this._chapterNo = chapterNo;
    }

    public int GetSequenceNo() {
        return this._sequenceNo;
    }

    public void SetSequenceNo(int sequenceNo) {
        this._sequenceNo = sequenceNo;
    }

    public int GetKeyTempo() {
        return this._keyTempo;
    }

    public void SetKeyTempo(int keyTempo) {
        this._keyTempo = keyTempo;
    }

    public int GetVoiceChange() {
        return this._voiceChange;
    }

    public void SetVoiceChange(int voiceChange) {
        this._voiceChange = voiceChange;
    }

    public int GetTelopSongMask() {
        return this._telopSongMask;
    }

    public void SetTelopSongMask(int telopSongMask) {
        this._telopSongMask = telopSongMask;
    }

    public int GetGuide() {
        return this._guide;
    }

    public void SetGuide(int guide) {
        this._guide = guide;
    }

    public int GetYourStory() {
        return this._yourStory;
    }

    public void SetYourStory(int yourStory) {
        this._yourStory = yourStory;
    }

    public int GetLocalId() {
        return this._localId;
    }

    public void SetLocalId(int localId) {
        this._localId = localId;
    }

    public int GetContentsType() {
        return this._contentsType;
    }

    public void SetContentsType(int contentsType) {
        this._contentsType = contentsType;
    }

    public long GetBackgroundMovie() {
        return this._backgroundMovie;
    }

    public void SetBackgroundMovie(long backgroundMovie) {
        this._backgroundMovie = backgroundMovie;
    }

    public int GetDmtVocal() {
        return this._dmtVocal;
    }

    public void SetDmtVocal(int dmtVocal) {
        this._dmtVocal = dmtVocal;
    }

    public byte[] GetReserve() {
        return this._reserve;
    }

    public void SetReserve(byte[] reserve) {
        this._reserve = reserve;
    }
}