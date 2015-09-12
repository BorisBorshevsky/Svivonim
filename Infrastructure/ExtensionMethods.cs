using System;

namespace Infrastructure
{
    internal static class ExtensionMethods
    {
        private static readonly ArgumentOutOfRangeException r_ArgumentOutOfRangeException =
            new ArgumentOutOfRangeException();

        public static bool IsInRange(this float i_STheNum, float i_Low, float i_High)
        {
            return i_STheNum <= i_High && i_STheNum >= i_Low;
        }

        public static void ThrowIfNotInRange(this float i_STheNum, float i_Low, float i_High)
        {
            if (i_STheNum > i_High || i_STheNum < i_Low)
            {
                throw r_ArgumentOutOfRangeException;
            }
        }
    }
}