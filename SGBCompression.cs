using System;
using System.Collections.Generic;
using System.Linq;

namespace SGB_Settings_Editor
{
    // SGB 1 Compression
    // Used in: Super Game Boy, Super Game Boy 2 (SGB2 exclusive borders are not compressed)
    //
    // Format
    // 6 byte header
    // AA AA BB BB CC CC
    // A = control word
    // B = size of compressed data in bytes - 2
    // C = size of original data in bytes, should be even (never read)
    //
    // Data
    // Contains normal data and 5 byte repetition actions that start with the control word.
    // No terminator sequence.
    //
    // Repetition action format:
    // AA AA BB BB CC
    // A = control word defined in header
    // B = offset in decompressed message
    // C = amount of words that get repeated starting from offset B
    // 
    // Decompression:
    // Copy words (2 bytes at a time) from data until the control word is read.
    // If control word is read, copy C words (C*2 bytes) starting from offset B in the decompressed message.
    // This action can continue to repeat bytes that are written by itself.
    // After copying C words continue with copying words from the input data starting after the repetition action.
    // Decompression is complete when the amount of bytes as stated in the header has been processed.
    //

    public static class SGBCompression
    {
        public static byte[] Decompress(byte[] data)
        {
            byte[] control = new byte[] { data[0], data[1] };
            int dataLength = BitConverter.ToInt16(data, 2);
            int messageLength = BitConverter.ToInt16(data, 4) + 2;

            List<byte> message = new List<byte>();

#if DEBUG
            Console.WriteLine($"Decoding {dataLength} byte data to {messageLength} byte message with control word {control[0].ToString("X2") + " " + control[1].ToString("X2")}.");
            if (data.Length < dataLength)
                Console.WriteLine($"Warning: Input data incomplete. Expected {dataLength} bytes, received {data.Length} bytes.");
#endif

            try
            {
                for (int i = 6; i < data.Length; i += 2)
                {
                    if ((data[i] == control[0]) && data[i + 1] == control[1])
                    { // repeat section
                        int offset = BitConverter.ToInt16(data, i + 2);
                        for (int repeat = data[i + 4] * 2; repeat > 0; repeat--)
                        { // this can repeat bytes that were newly added to the message in this loop
                            message.Add(message[offset]);
                            offset++;
                        }
                        i += 3;
                    }
                    else
                    { // copy normal words
                        message.Add(data[i]);
                        message.Add(data[i + 1]);
                    }
                    if (message.Count >= messageLength) // reached end of message
                        break;
                }
            }
            catch { } // reached end of data before finishing the message, or offset of repetition action was invalid
            return message.ToArray();
        }

        public static byte[] Compress(byte[] data)
        {
            if (data.Length > 0xFFFF) // max size
                return data;

            if (data.Length % 2 == 1)
                data = data.Concat(new byte[] { 0x00 }).ToArray();

            byte[] control = FindControlWord(data);
            if (control == null) // couldn't find control word
                return data;

            List<byte> buffer = new List<byte>();
            ushort pointer = 0;

            while (pointer < data.Length)
            {
                var (count, offset) = RepeatingBytes(data, pointer);
                if (count >= 4)
                {
                    buffer.AddRange(control);
                    buffer.AddRange(BitConverter.GetBytes(offset));
                    buffer.Add(count);
                    pointer += (ushort)(count * 2);
                }
                else
                {
                    buffer.Add(data[pointer]);
                    buffer.Add(data[pointer + 1]);
                    pointer += 2;
                }
            }

            byte[] messageLength = BitConverter.GetBytes(data.Length > 4 ? data.Length - 2 : 2);
            byte[] compressedLength = BitConverter.GetBytes(buffer.Count);

            byte[] header = new byte[] {
                control[0], control[1], compressedLength[0], compressedLength[1], messageLength[0], messageLength[1]
            };

            buffer.InsertRange(0, header);

            return buffer.ToArray();
        }

        private static byte[] FindControlWord(byte[] data)
        {
            byte[] control = null;
            for (ushort i = 0; i <= 0xFFFF; i++)
            {
                byte[] controlBytes = BitConverter.GetBytes(i);
                bool unused = true;
                for (int j = 0; j < data.Length; j += 2)
                {
                    if (data[j] == controlBytes[0] && data[j + 1] == controlBytes[1])
                    {
                        unused = false;
                        break;
                    }
                }
                if (unused)
                {
                    control = controlBytes;
                    break;
                }
            }
            return control;
        }

        private static (byte count, ushort offset) RepeatingBytes(byte[] data, ushort pointer)
        {
            byte maxCount = 0;
            ushort maxCountOffset = 0;
            for (ushort i = 0; i < pointer - 1; i++) // search from beginning of message to 1 word behind current position
            {
                int j = 0;
                byte count = 0;
                while (((pointer + j + 1) < data.Length) && data[i + j] == data[pointer + j] && data[i + j + 1] == data[pointer + j + 1] && count < 0xFE)
                {
                    count++;
                    j += 2;
                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxCountOffset = i;
                    }
                }
            }
            return (maxCount, maxCountOffset);
        }
    }
}