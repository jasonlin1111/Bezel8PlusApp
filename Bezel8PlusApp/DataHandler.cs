using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bezel8PlusApp
{
    public enum ConfigType
    {
        ICC = 0,
        PCD = 1
    }

    class DataHandler
    {
        public static int UICFormatConvertor(string format)
        {
            if (string.IsNullOrEmpty(format))
                return 7;

            if (Int32.TryParse(format, out int iFormat))
                return iFormat;

            switch (format.ToLower())
            {
                case "a": return 1;
                case "b": return 2;
                case "an": return 3;
                case "ans": return 4;
                case "cn": return 5;
                case "n": return 6;
                default: return 7;
            }
        }

        public static bool IsHexString(string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, @"\A\b[0-9a-fA-F]+\b\Z");
        }

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

        public static List<TLVDataObject> ToDataObjList(byte[] bytes)
        {
            List<TLVDataObject> DOList = new List<TLVDataObject>();

            if (bytes == null)
                return null;
            if (bytes.Length == 0)
                return DOList;

            return DOList;
        }

        /// <summary>
        /// input: string "B6004000", return byte[] { 0xB6, 0x00, 0x40, 0x00 }
        /// </summary>
        public static byte[] HexStringToByteArray(string hexString)
        {
            if (string.IsNullOrEmpty(hexString))
                return null;

            if (hexString.Length % 2 != 0)
                hexString = hexString.PadLeft(hexString.Length + 1, '0');

            byte[] byteOUT = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i = i + 2)
            {
                byteOUT[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return byteOUT;
        }

        /// <summary>
        /// { 0xFF, 0xD0, 0xFF, 0xD1 } to "FFD0FFD1"
        /// </summary>
        public static string ByteArrayToHexString(byte[] byteArray)
        {
            return BitConverter.ToString(byteArray).Replace("-" ,"");
        }

        public static string ConvertHexToAscii(string hexString)
        {
            string ascii = String.Empty;

            for (int i = 0; i < hexString.Length; i += 2)
            {
                String hs = string.Empty;

                hs = hexString.Substring(i, 2);
                uint decval = System.Convert.ToUInt32(hs, 16);
                char character = System.Convert.ToChar(decval);
                ascii += character;
            }
            return ascii;
        }

        public static string ConvertLoggingMessage(byte[] buffer)
        {
            string output = String.Empty;

            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] < 0x20)
                {
                    output += "<" + buffer[i].ToString("X2") + ">";
                }
                else
                {
                    output += Convert.ToChar(buffer[i]).ToString();
                }
            }

            return output;
        }
    }

    class TLVDataObject
    {
        //private byte[] _tag;
        //private byte[] _length;
        //private byte[] _value;
        //private bool _isPrimitiveDataObject;

        public const byte SubsequentByteMask = 0x1F;
        public const byte AnotherByteMask = 0x80;
        public const byte ConstructedDOMask = 0x20;

        public TLVDataObject()
        {
            Tag = null;
            Length = -1;
            Value = null;
            IsConstructed = false;
        }

        public byte[] Tag { get; set; }

        public int Length { get; set; }

        public byte[] Value { get; set; }

        public bool IsConstructed { get; set; }

        private byte[] GetTag(ref byte[] TLVData, ref int offset)
        {
            if (offset >= TLVData.Length)
                return null;

            List<byte> tag = new List<byte>();
            tag.Add(TLVData[offset]);

            if ((TLVData[offset] & ConstructedDOMask) == ConstructedDOMask)
                IsConstructed = true;
            else
                IsConstructed = false;

            bool isNext = (TLVData[offset] & SubsequentByteMask) == SubsequentByteMask;
            offset++;
            while (isNext && offset < TLVData.Length)
            {
                tag.Add(TLVData[offset]);
                offset++;
                isNext = (TLVData[offset] & AnotherByteMask) == AnotherByteMask;
            }
            return tag.ToArray();
        }

        private int GetLength(ref byte[] TLVData, ref int offset)
        {
            if (offset >= TLVData.Length)
                return -1;

            int length = 0;

            if ((TLVData[offset] & AnotherByteMask) == 0)
            {
                length = (int)TLVData[offset];
                offset++;
                return length;
            }

            var lengthBytes = TLVData[offset] & 0x7F;
            offset++;
            for (var i = 0; i < lengthBytes; i++)
            {
                if (offset < TLVData.Length)
                {
                    length <<= 8;
                    length |= (int)TLVData[offset++];
                }   
            }
            return length;

        }


        private void Parse(ref byte[] TLVData, ref int offset)
        {
            Tag = GetTag(ref TLVData, ref offset);

            Length = GetLength(ref TLVData, ref offset);

            if (Length > 0 && offset + Length <= TLVData.Length)
            {
                Value = new byte[Length];
                Array.Copy(TLVData, offset, Value, 0, Length);
            }
            offset += Length;
        }

        public static List<TLVDataObject> ConvertToTLVList(string tlvString)
        {
            byte[] TLVData = DataHandler.HexStringToByteArray(tlvString);
            if (TLVData == null)
                return null;

            List<TLVDataObject> TLVList = new List<TLVDataObject>();

            int offset = 0;
            while (offset < TLVData.Length - 1)
            {
                TLVDataObject dataObject = new TLVDataObject();
                dataObject.Parse(ref TLVData, ref offset);
                TLVList.Add(dataObject);          
            }
            return TLVList;
        }

        public string TagString(string separator = "")
        {
            if (Tag == null)
                return null;
            else if (Tag.Length == 0)
                return String.Empty;
            else
                return BitConverter.ToString(Tag).Replace("-", separator);
        }

        public string ValueString(string separator = "")
        {
            if (Value == null)
                return null;
            else if (Value.Length == 0)
                return String.Empty;
            else
                return BitConverter.ToString(Value).Replace("-", separator);
        }

    }
}
