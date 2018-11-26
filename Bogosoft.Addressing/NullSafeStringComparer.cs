using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Bogosoft.Addressing
{
    static class NullSafeStringComparer
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int Xor(int lhs, int rhs) => lhs ^ rhs;

        static readonly IEqualityComparer<string> Source = StringComparer.OrdinalIgnoreCase;

        internal static bool Equals(string x, string y) => Source.Equals(x, y);

        internal static int GetHashCode(string str) => str == null ? 0 : Source.GetHashCode(str);

        internal static int GetHashCode(IEnumerable<string> strings) => strings.Select(GetHashCode).Aggregate(0, Xor);

        internal static int GetHashCode(params string[] strings) => strings.Select(GetHashCode).Aggregate(0, Xor);
    }
}