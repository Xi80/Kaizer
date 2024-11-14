namespace KaizerCommanderApi;

public static class MemoryStreamExtension
{
    public static ushort ReadUInt16B(this Stream stream)
    {
        var t = (ushort)(stream.ReadByte() << 8);
        t|= (ushort)(stream.ReadByte() << 0);
        return t;
    }
    
    public static void WriteUInt16B(this Stream stream,ushort value)
    {
        stream.WriteByte((byte)(value >> 8));
        stream.WriteByte((byte)(value & 0xFF));
    }

    public static uint ReadUInt32B(this Stream stream)
    {
        var t = (uint)(stream.ReadByte() << 24);
        t |= (uint)(stream.ReadByte() << 16);
        t |= (uint)(stream.ReadByte() << 8);
        t |= (uint)(stream.ReadByte() << 0);
        return t;
    }
}