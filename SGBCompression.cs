using System;
using System.Collections.Generic;

namespace SGB_Palette_Editor
{
    // SGB 1 Compression
    // Used in: Super Game Boy, Super Game Boy 2 (SGB2 exclusive borders are not compressed)
    //
    // Format
    // 6 byte header
    // AA AA BB BB CC CC
    // A = control word
    // B = size of compressed data in bytes
    // C = size of original data in bytes, must be even
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
        public static List<byte> Decompress(byte[] data)
        {
            byte[] control = new byte[] { data[0], data[1] };
            int dataLength = BitConverter.ToInt16(data, 2);
            int messageLength = BitConverter.ToInt16(data, 4); // I didn't actually verify that this is the length, but it looks reasonable and works

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
                        message.Add(data[i + 1]); // it might be possible that this index is out of range, but that's fine
                    }
                    if (message.Count >= messageLength) // reached end of message
                        break;
                }
            }
            catch { } // reached end of data before finishing the message, or offset of repetition action was invalid
            return message;
        }
    }
}
