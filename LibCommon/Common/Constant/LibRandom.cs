using System;

namespace Common.Constant
{
    public static class LibRandom
    {
        private static Random random = new Random();

        public static bool GetRandomBoolean()
        {
            return random.Next(2) == 0;
        }
    }
}
