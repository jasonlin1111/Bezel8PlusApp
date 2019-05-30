using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bezel8PlusApp
{
    class DataHandler
    {

        public static char CalculateLRC(string toEncode)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(toEncode);
            byte LRC = 0;
            for (int i = 1; i < bytes.Length; i++)
            {
                LRC ^= bytes[i];
            }
            return Convert.ToChar(LRC);
        }

        public static byte LRCCalculator(byte[] input, int length)
        {
            byte LRC = 0;

            if (length > input.Length)
            {
                length = input.Length;
            }

            for (int i = 1; i < length; i++)
            {
                LRC ^= input[i];
            }

            return LRC;
        }

        public static byte[] ToByte(string input)
        {
            if (input.Length % 2 != 0)
            {
                input = input.PadLeft(input.Length + 1, '0');
            }
            byte[] byteArray = new byte[input.Length / 2];

            for (int i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = byte.Parse(input.Substring(2*i, 2), System.Globalization.NumberStyles.HexNumber);
            }

            return byteArray;
        }
    }
}
