using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Graphs.Tests
{
    public static class ListHelpers<T> where T:struct
    {
        public static bool AreEqual(List<T> list1, List<T> list2)
        {
            if (list1 == null && list2 == null)
            {
                return true;
            }

            if((list1 == null && list2!=null)
                ||(list1 != null && list2==null))
            {
                return false;
            }

            if (list1.Count != list2.Count)
            {
                return false;
            }

            list1.Sort();
            list2.Sort();

            int itemsCount = list1.Count;
            var list1Array = list1.ToArray();
            var list2Array = list2.ToArray();
            for (int i = 0; i < itemsCount; i++)
            {
                if (list1Array[i].Equals(list2Array[i]))
                {
                    return false; 
                }
            }

            return true;
        }
    }
}
