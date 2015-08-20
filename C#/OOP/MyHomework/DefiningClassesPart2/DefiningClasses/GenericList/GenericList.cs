namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GenericList<T> where T : IComparable<T>
    {
        private T[] myElements;
        private int count;

        public GenericList(int capacity)
        {
            this.myElements = new T[capacity];
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        //public T[] MyElements
        //{
        //    get
        //    {
        //        return this.myElements;
        //    }
        //    private set
        //    {
        //        this.myElements = value;
        //    }
        //}


        public T this[int index]
        {
            get
            {
                CheckIndex(index);
                return this.myElements[index];
            }
            set
            {
                CheckIndex(index);
                this.myElements[index] = value;
                if (index >= this.Count)
                {
                    this.count = index + 1;
                }
            }
        }

        public void AddElement(T element)
        {
            AutoGrow();
            this.myElements[this.Count] = element;
            this.count++;
        }

        public int FindElement(T element)
        {
            int position = 0;

            for (int i = 1; i <= this.myElements.Length; i++)
            {
                if (this.myElements[i - 1].Equals(element))
                {
                    break;
                }
                if (i == this.myElements.Length)
                {
                    return -1;
                }
                position++;
            }
            return position;
        }

        public void Clear()
        {
            for (int i = 0; i < this.myElements.Length; i++)
            {
                this.myElements[i] = default(T);
            }
            this.count = 0;
        }

        public void InsertElement(int index, T element)
        {
            CheckIndex(index);
            CountingElements();
            AutoGrow();
            for (int i = index + 1; i < this.myElements.Length; i++)
            {
                this.myElements[i - 1] = this.myElements[i];
            }
            this.myElements[index] = element;
            CountingElements();
        }

        public void RemoveElementAt(int index)
        {
            CheckIndex(index);
            if (this.myElements[index].Equals(default(T)))
            {
            }
            else
            {
                for (int i = index + 1; i < this.myElements.Length; i++)
                {
                    this.myElements[i - 1] = this.myElements[i];
                }
                this.myElements[this.Count] = default(T);
                this.count--;
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= this.myElements.Length)
            {
                throw new ArgumentOutOfRangeException("Wrong index");
            }
        }

        private void CountingElements()
        {
            int tempCount = 0;
            foreach (var item in this.myElements)
            {
                if (item.Equals(default(T)))
                { tempCount++; }
                else
                {
                    tempCount++;
                    if (this.Count <= tempCount)
                        this.count = tempCount;
                }
            }
        }

        private void AutoGrow()
        {
            if (this.Count + 1 >= this.myElements.Length)
            {
                int size = 0;
                if (this.myElements.Length == 0)
                    size = 2;
                else
                    size = this.myElements.Length * 2;
                T[] newArr = new T[size];
                for (int i = 0; i < this.myElements.Length; i++)
                {
                    newArr[i] = this.myElements[i];
                }
                this.myElements = newArr;
            }
        }

        public T Min()
        {
            T result = default(T);
            if (this.myElements.Length > 0)
            {
                result = this.myElements[0];
                foreach (var item in this.myElements)
                {
                    if (result.CompareTo(item) > 0)
                    {
                        result = item;
                    }
                }
            }
            else
                throw new ArgumentException("There is no Min element in that collection");
            return result;
        }

        public T Max()
        {
            T result = default(T);
            if (this.myElements.Length > 0)
            {
                result = this.myElements[0];
                foreach (var item in this.myElements)
                {
                    if (result.CompareTo(item) < 0)
                    {
                        result = item;
                    }
                }
            }
            else
                throw new ArgumentException("There is no Min element in that collection");
            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (T item in this.myElements)
            {
                result.AppendLine(item.ToString());
            }
            return result.ToString();
        }
    }
}
