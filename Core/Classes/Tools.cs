using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace GenArt.Classes
{
    public static class Tools
    {
        private static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        public static readonly int MaxPolygons = 250;

        public static int seed = Environment.TickCount;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRandomNumber(int min, int max)
        {
            return random.Value.Next(min, max);
        }

        public static int MaxWidth = 200;
        public static int MaxHeight = 200;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool WillMutate(int mutationRate)
        {
            return GetRandomNumber(0, mutationRate) == 1;
        }
    }
}