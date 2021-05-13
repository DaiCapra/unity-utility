using UnityEngine;

namespace Utility.Extensions
{
    public static class ColorExtensions
    {
        // input example: #E7AC54
        public static Color FromHexString(string hex)
        {
            return ColorUtility.TryParseHtmlString(hex, out var c) ? c : default;
        }
    }
}