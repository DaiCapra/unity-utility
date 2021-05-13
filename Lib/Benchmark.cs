using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Utility.Lib
{
    public static class Benchmark
    {
        public static long MeasureTime(Action action, int iterations = 1, bool log = true)
        {
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < iterations; i++)
            {
                action?.Invoke();
            }

            sw.Stop();

            if (log)
            {
                Debug.Log($"Total: {sw.ElapsedMilliseconds} ms, I: {sw.ElapsedMilliseconds/(float)iterations} ms");
            }

            return sw.ElapsedMilliseconds;
        }
    }
}