using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses.GenericList
{
    class TestGenericList
    {
        static void Main()
        {
            GenericList<int> list = new GenericList<int>(5);
            StringBuilder result = new StringBuilder();
            list.AddElement(5);
            list.InsertElement(1, 2);
            list.InsertElement(3, 1);
            result.AppendLine(list.ToString());
            result.AppendLine(String.Format("Count: {0}", list.Count));

            result.AppendLine("WHERE IS 1?");
            result.AppendLine(list.FindElement(1).ToString());

            result.AppendLine("REMOVE INDEX 1");
            list.RemoveElementAt(1);
            result.AppendLine(list.ToString());
            result.AppendLine(String.Format("Count: {0}", list.Count));

            result.AppendLine("WHERE IS 1?");
            result.AppendLine(list.FindElement(1).ToString());

            result.AppendLine("ADD MORE ELEMENTS TO TEST EXPANDING");
            list.AddElement(10);
            list.AddElement(6);
            list.AddElement(7);
            result.AppendLine(list.ToString());
            result.AppendLine(String.Format("Count: {0}", list.Count));

            result.AppendLine("WHERE IS 1?");
            result.AppendLine(list.FindElement(1).ToString());
            result.AppendLine("WHERE IS 5?");
            result.AppendLine(list.FindElement(5).ToString());

            result.AppendLine("CLEAR ALL");
            list.Clear();
            result.AppendLine(list.ToString());
            result.AppendLine(String.Format("Count: {0}", list.Count));

            Console.WriteLine(result);
        }
    }
}
