namespace KaizerCommanderApi;

public class SongInformation
{
    public const ushort Size = 0x18;
    private long time = 0;      /* 予約した時点のUnixタイム? */
    private int trayNo = 0;     /* 選曲番号上4桁*/
    private int chapterNo = 0;  /* 選曲番号下2桁*/
    private int sequenceNo = 0;
    private int keyTempo = 0;
    private int voiceChange = 0;
    private int telopSongMask = 0;
    private int guide = 0;
    private int yourStory = 0;
    private int localId = 0;
    private int contentsType = 0;
    private long backgroundMovie = 0;
    private int dmtVocal = 0;
    private byte[] reserve = new byte[3];

    public void SetValueFromMemoryStream(MemoryStream stream)
    {
        time = stream.ReadUInt32B();
        trayNo = stream.ReadUInt16B();
        chapterNo = stream.ReadByte();
        sequenceNo = stream.ReadByte();
        keyTempo = stream.ReadByte();
        voiceChange = stream.ReadByte();
        telopSongMask = stream.ReadByte();
        guide = stream.ReadByte();
        yourStory = stream.ReadByte();
        localId = stream.ReadByte();
        contentsType = stream.ReadUInt16B();
        backgroundMovie = stream.ReadUInt32B();
        dmtVocal = stream.ReadByte();
        _ = stream.Read(reserve, 0, reserve.Length);
    }
    
    public long GetTime() {
        return this.time;
    }

    public void SetTime(long time) {
        this.time = time;
    }

    public int GetTrayNo() {
        return this.trayNo;
    }

    public void SetTrayNo(int trayNo) {
        this.trayNo = trayNo;
    }

    public int GetChapterNo() {
        return this.chapterNo;
    }

    public void SetChapterNo(int chapterNo) {
        this.chapterNo = chapterNo;
    }

    public int GetSequenceNo() {
        return this.sequenceNo;
    }

    public void SetSequenceNo(int sequenceNo) {
        this.sequenceNo = sequenceNo;
    }

    public int GetKeyTempo() {
        return this.keyTempo;
    }

    public void SetKeyTempo(int keyTempo) {
        this.keyTempo = keyTempo;
    }

    public int GetVoiceChange() {
        return this.voiceChange;
    }

    public void SetVoiceChange(int voiceChange) {
        this.voiceChange = voiceChange;
    }

    public int GetTelopSongMask() {
        return this.telopSongMask;
    }

    public void SetTelopSongMask(int telopSongMask) {
        this.telopSongMask = telopSongMask;
    }

    public int GetGuide() {
        return this.guide;
    }

    public void SetGuide(int guide) {
        this.guide = guide;
    }

    public int GetYourStory() {
        return this.yourStory;
    }

    public void SetYourStory(int yourStory) {
        this.yourStory = yourStory;
    }

    public int GetLocalId() {
        return this.localId;
    }

    public void SetLocalId(int localId) {
        this.localId = localId;
    }

    public int GetContentsType() {
        return this.contentsType;
    }

    public void SetContentsType(int contentsType) {
        this.contentsType = contentsType;
    }

    public long GetBackgroundMovie() {
        return this.backgroundMovie;
    }

    public void SetBackgroundMovie(long backgroundMovie) {
        this.backgroundMovie = backgroundMovie;
    }

    public int GetDmtVocal() {
        return this.dmtVocal;
    }

    public void SetDmtVocal(int dmtVocal) {
        this.dmtVocal = dmtVocal;
    }

    public byte[] GetReserve() {
        return this.reserve;
    }

    public void SetReserve(byte[] reserve) {
        this.reserve = reserve;
    }
}