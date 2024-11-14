namespace KaizerCommanderApi;

public static class MemoryStreamExtension
{
    public static UInt16 ReadUInt16B(this Stream stream)
    {
        var t = (UInt16)(stream.ReadByte() << 8);
        t|= (UInt16)(stream.ReadByte() << 0);
        return t;
    }
    
    public static void WriteUInt16B(this Stream stream,ushort value)
    {
        stream.WriteByte((byte)(value >> 8));
        stream.WriteByte((byte)(value & 0xFF));
    }
}