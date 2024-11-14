namespace KaizerCommanderApi;

public abstract class KserverCommandReply
{
    public KserverHeader Header;

    public abstract void SetValueFromMemoryStream(MemoryStream stream);

    public ushort GetReplyId()
    {
        return Header.GetMessageId();
    }
}