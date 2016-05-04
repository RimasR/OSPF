using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSPF
{
    public static class ExtensionMethods
    {
        public static bool IsEmpty<T>(this IEnumerable<T> list)
        {
            if (list is ICollection<T>) return ((ICollection<T>)list).Count == 0;

            return !list.Any();
        }
    }
}
