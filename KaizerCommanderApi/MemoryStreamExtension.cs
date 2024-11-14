using System.Text;

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

    public static void WriteUInt32B(this Stream stream, uint value)
    {
        stream.WriteByte((byte)((value >> 24) & 0xFF));
        stream.WriteByte((byte)((value >> 16) & 0xFF));
        stream.WriteByte((byte)((value >> 8) & 0xFF));
        stream.WriteByte((byte)(value & 0xFF));
    }

    public static string ReadString(this Stream stream, int length)
    {
        if (stream.Length < length)
        {
            return "";
        }
        
        var t = new byte[length];
        var isNotAllZero = false;
        
        for (int i = 0; i < length; i++)
        {
            t[i] = (byte)stream.ReadByte();
            if (t[i] != 0x00)
            {
                isNotAllZero = true;
            }
        }

        if (!isNotAllZero)
        {
            return "";
        }

        try
        {
            return Encoding.UTF8.GetString(t);
        }
        catch (Exception e)
        {
            return "";
        }
    }
}