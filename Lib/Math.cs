using UnityEngine;

namespace Utility.Lib
{
    public static class Math
    {
        public static bool IsBitSet(int b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }
        public static int Modulus(int a, int n)
        {
            int r = a % n;
            return r < 0 ? r + n : r;
        }
    }
}