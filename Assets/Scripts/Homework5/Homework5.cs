using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework5
{
    public static class Homework5
    {
        public static void DoJob()
        {
            string s = "Строка с символами";
            s.CharCount();
            AnotherHomework5<int> anotherHomework5 = new AnotherHomework5<int>();
            List<int> list = new List<int>() {1, 2, 3, 4, 5, 2, 3, 5, 5};
            anotherHomework5.CountElements(list);
            
            AnotherHomework5<string> anotherHomework = new AnotherHomework5<string>();
            List<string> anotherList = new List<string>() {"раз", "два", "три", "два"};
            anotherHomework.CountElements(anotherList);
        }

        public static int CharCount(this string str)
        {
            return str.Length;
        }
    }

    public class AnotherHomework5<T>
    {
        public void CountElements(List<T> list)
        {
            var z = from x in list
                group x by x into g
                let count = g.Count()
                select new {Name = g.Key, Count = count};
            foreach (var variable in z)
            {
                Console.WriteLine($"{variable.Name} = {variable.Count}");
            }
        }
    }
}
