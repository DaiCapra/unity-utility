using UnityEngine;

namespace Utility.Lib
{
    public static class MathLib
    {
        public static bool IsBitSet(int mask, int pos)
        {
            return (mask & (1 << pos)) != 0;
        }
        public static int Modulus(int a, int n)
        {
            int r = a % n;
            return r < 0 ? r + n : r;
        }
    }
}