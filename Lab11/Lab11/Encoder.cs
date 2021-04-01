using System.IO;
using System;

namespace Lab11
{
    public static class Encoder
    {
        public static bool TryEncode(Stream input, Stream output)
        {
            if (input.Length == 0)
            {
                return false;
            }

            byte count = 1;
            int currentAscii = input.ReadByte();
            int nextAscii;

            for (int i = 1; i <= input.Length; i++)
            {
                nextAscii = input.ReadByte();

                if (currentAscii == nextAscii && count < 255)
                {
                    count++;
                }
                else 
                {
                    output.WriteByte(count);
                    output.WriteByte((byte)currentAscii);
                    count = 1;
                }
                currentAscii = nextAscii;
            }
            return true;
        }

        public static bool TryDecode(Stream input, Stream output)
        {
            if (input.Length == 0)
            {
                return false;
            }

            for (int i = 0; i < input.Length; i = i + 2)
            {
                int count = input.ReadByte();
                int currentAscii = input.ReadByte();

                for (int j = 0; j < count; j++)
                {
                    output.WriteByte((byte)currentAscii);
                }
            }
            return true;
        }
    }
}
