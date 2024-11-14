namespace KaizerCommanderApi;

public class ManipulateReserveListReply : KserverCommandReply
{
    private const ushort SizeExceptList = 0x38;
    private int _result;
    private int _numberOfReserveSongs;
    private SongInformation _playingSongInformation = new();
    private SongInformation _interruptSongInformation = new();
    private List<SongInformation> _reserveSongInformationList = new();

    public override void SetValueFromMemoryStream(MemoryStream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);
        Header = KserverHeader.GenerateHeaderFromMemoryStream(stream);
        _result = stream.ReadUInt16B();
        _numberOfReserveSongs = stream.ReadUInt16B();
        _playingSongInformation.SetValueFromMemoryStream(stream);
        _interruptSongInformation.SetValueFromMemoryStream(stream);
        for (int i = 0; i < _numberOfReserveSongs; i++)
        {
            SongInformation s = new();
            s.SetValueFromMemoryStream(stream);
            _reserveSongInformationList.Add(s);
        }
    }

    public int GetResult()
    {
        return _result;
    }
    
    public void SetResult(int result) {
        this._result = result;
    }

    public int GetNumberOfReserveSongs() {
        return this._numberOfReserveSongs;
    }

    public void SetNumberOfReserveSongs(int numberOfReserveSongs) {
        this._numberOfReserveSongs = numberOfReserveSongs;
    }

    public SongInformation GetPlayingSongInformation() {
        return this._playingSongInformation;
    }

    public void SetPlayingSongInformation(SongInformation playingSongInformation) {
        this._playingSongInformation = playingSongInformation;
    }

    public SongInformation GetInterruptSongInformation() {
        return this._interruptSongInformation;
    }

    public void SetInterruptSongInformation(SongInformation interruptSongInformation) {
        this._interruptSongInformation = interruptSongInformation;
    }

    public List<SongInformation> GetReserveSongInformationList() {
        return this._reserveSongInformationList;
    }

    public void SetReserveSongInformationList(List<SongInformation> reserveSongInformationList) {
        this._reserveSongInformationList = reserveSongInformationList;
    }
}