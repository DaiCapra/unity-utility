using System.Globalization;
using UnityEngine;

namespace Utility.Extensions
{
    public static class ColorExtensions
    {
        // input example: #E7AC54
        public static Color FromHexString(string hex)
        {
            var c = (Color) ToColor(hex);
            return c;
            // return ColorUtility.TryParseHtmlString(hex, out var c) ? c : default;
        }

        // https://answers.unity.com/questions/812240/convert-hex-int-to-colorcolor32.html
        private static Color32 ToColor(string hex)
        {
            if (string.IsNullOrEmpty(hex))
            {
                return default;
            }

            if (hex.StartsWith("#"))
            {
                hex = hex[1..];
            }
            
            //assume fully visible unless specified in hex
            byte a = 255; 
            var numberStyles = NumberStyles.HexNumber;
            byte r = byte.Parse(hex.Substring(0, 2), numberStyles);
            byte g = byte.Parse(hex.Substring(2, 2), numberStyles);
            byte b = byte.Parse(hex.Substring(4, 2), numberStyles);
            
            //Only use alpha if the string has enough characters
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(6, 2), numberStyles);
            }

            return new Color32(r, g, b, a);
        }
    }
}