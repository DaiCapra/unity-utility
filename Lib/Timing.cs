using System.Threading.Tasks;
using UnityEngine;

namespace Utility.Lib
{
    public static class Timing
    {
        public static async Task WaitForFrames(int frames)
        {
            for (int i = 0; i < frames; i++)
            {
                await new WaitForEndOfFrame();
            }
        }
    }
}