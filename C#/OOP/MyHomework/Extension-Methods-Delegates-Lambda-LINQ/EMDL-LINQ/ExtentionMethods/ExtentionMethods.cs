namespace EMDL_LINQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class ExtentionMethods
    {
        public static StringBuilder Substring(this StringBuilder text, int index, int length)
        {
            text.CheckLength(index, length);
            StringBuilder result = new StringBuilder();
            for (int i = index; i < text.Length - length; i++)
            {
                result.Append(text[i]);
            }
            return result;
        }

        private static void CheckLength(this StringBuilder text, int index, int length)
        {
            if (text.Length <= index + length)
            {
                throw new ArgumentOutOfRangeException("Wrong substring length given!");
            }
        }

        public static T Sum<T>(this IEnumerable<T> collection)
        {
            T result = default(T);
            foreach (var item in collection)
            {
                result += (dynamic)item;
            }
            return result;
        }

        public static T Product<T>(this IEnumerable<T> collection)
        {
            dynamic result = 1;
            foreach (var item in collection)
            {
                result *= item;
            }
            return result;
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentNullException("Empty collection");
            }
            T result = collection.ElementAt(0);
            foreach (var item in collection)
            {
                if (item.CompareTo(result) < 0)
                {
                    result = item;
                }
            }
            return result;
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentNullException("Empty collection");
            }
            T result = collection.ElementAt(0);
            foreach (var item in collection)
            {
                if (item.CompareTo(result) > 0)
                {
                    result = item;
                }
            }
            return result;
        }

        public static double Average<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            double result = 0.0;
            foreach (var item in collection)
            {
                result += (dynamic)item;
            }
            return result / (collection.Count() + 1);
        }
    }
}
