namespace BravoGame
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Threading;

    #endregion

    /// <summary>
    /// The extension.
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// The Fisher-Yates shuffle
        /// </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;

            while (n > 1)
            {
                n--;
                var k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// The thread safe random.
        /// </summary>
        public static class ThreadSafeRandom
        {
            /// <summary>
            /// The local.
            /// </summary>
            [ThreadStatic]
            private static Random Local;

            /// <summary>
            /// Gets the this threads random.
            /// </summary>
            public static Random ThisThreadsRandom => Local ?? (Local = new Random(
                                                                    unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));
        }
    }
}