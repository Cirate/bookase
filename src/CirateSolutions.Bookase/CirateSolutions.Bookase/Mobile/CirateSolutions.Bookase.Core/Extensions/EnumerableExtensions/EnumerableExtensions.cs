using System.Collections.Generic;

namespace CirateSolutions.Bookase.Core.Extensions.EnumerableExtensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> EncloseInEnumerable<T>(this T value) => new[] { value };
    }
}