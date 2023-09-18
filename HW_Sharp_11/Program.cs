using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace HW_Sharp_11
{
    struct RGB
    {
        byte Red;
        byte Green;
        byte Blue;

        public byte r
        {
            get
            {
                return Red;
            }
            set
            {
                Red = value;
            }
        }
        public byte g
        {
            get
            {
                return Green;
            }
            set
            {
                Green = value;
            }
        }
        public byte b
        {
            get
            {
                return Blue;
            }
            set
            {
                Blue = value;
            }
        }
        public RGB(byte r = 0, byte g = 0, byte b = 0)
        {
            Red = r;
            Green = g;
            Blue = b;
        }
        public string ToHex()
        {
            char[] convHex = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'};
            string temp = ""; 
            temp += "" + convHex[Red / 16] + "" + convHex[Red % 16] + "" + convHex[Green / 16] + "" + convHex[Green % 16] + 
                    "" + convHex[Blue / 16] + "" + convHex[Blue % 16];
            return temp;
        }
        public string ToHSL()
        {
            string temp = "";
            float _R = (Red / 255f);
            float _G = (Green / 255f);
            float _B = (Blue / 255f);

            float _Min = Math.Min(Math.Min(_R, _G), _B);
            float _Max = Math.Max(Math.Max(_R, _G), _B);
            float _Delta = _Max - _Min;

            float H = 0;
            float S = 0;
            float L = (float)((_Max + _Min) / 2.0f);

            if (_Delta != 0)
            {
                if (L < 0.5f)
                {
                    S = (float)(_Delta / (_Max + _Min));
                }
                else
                {
                    S = (float)(_Delta / (2.0f - _Max - _Min));
                }


                if (_R == _Max)
                {
                    H = (_G - _B) / _Delta;
                }
                else if (_G == _Max)
                {
                    H = 2f + (_B - _R) / _Delta;
                }
                else if (_B == _Max)
                {
                    H = 4f + (_R - _G) / _Delta;
                }
            }

            H *= 60;
            if (H < 0)
            {
                H += 360;
            }
            S *= 100;
            L *= 100;

            temp += "Hue: " + H + "\nSaturation: " + S + "\nLightness: " + L;
            return temp;
        }
        public string ToCMYK()
        {
            string temp = "";

            float R = (float)Red / 255;
            float G = (float)Green / 255;
            float B = (float)Blue / 255;

            float K = 1 - Math.Max(Math.Max(R, G), B);
            float C = (1 - R - K) / (1 - K);
            float M = (1 - G - K) / (1 - K);
            float Y = (1 - B - K) / (1 - K);

            K *= 100;
            C *= 100;
            M *= 100;
            Y *= 100;

            temp += "Black Key: " + K + '%' + "\nCyan: " + C + '%' + "\nMagenta: " + M + '%' + "\nYellow: " + Y + '%';
            return temp;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            RGB test = new RGB(255, 0, 0);
            Console.WriteLine(test.ToHex());
            Console.WriteLine(test.ToHSL());
            Console.WriteLine(test.ToCMYK());
        }
    }
}
