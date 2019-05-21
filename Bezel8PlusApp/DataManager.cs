using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bezel8PlusApp
{
    class DataManager
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

        static public byte LRCCalculator(byte[] input, int length)
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
    }
}
