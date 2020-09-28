using System;
using System.Globalization;

namespace String_Compression_OR_Run_Length_Encoding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CompressAnother(new char[] { 'a', 'b', 'b', 'b', 'c', 'c', 'c' }));
        }

        static int Compress(char[] chars)
        {
            int length = chars.Length;
            if (length == 0) return 0;
            int count = 1, index = 0, tempIndex = 0;
            while(index < length)
            {
                if( index < length - 1 && chars[index] == chars[index+1])
                {
                    count++;
                }
                else
                {
                    chars[tempIndex++] = chars[index];
                    if (count != 1)
                    {
                        foreach (char c in count.ToString()) chars[tempIndex++] = c;
                    }

                    count = 1;
                }

                index++;
            }
            return tempIndex;
        }

        static int CompressAnother(char[] chars)
        {
            int length = chars.Length;
            if (length == 0) return 0;
            int count = 0, index = 0, tempIndex = 0;
            while (index < length)
            {
                char c = chars[index];
                while (index < length && chars[index] == c)
                {
                    count++;
                    index++;
                }

                chars[tempIndex++] = c;
                if (count != 1)
                {
                    foreach (char ch in count.ToString()) chars[tempIndex++] = ch;
                }

                count = 0;
            }
            return tempIndex;
        }
    }
}
