namespace Schools
{
    using System;
    using System.Collections.Generic;
    using System.Collections;

    public class School
    {
        public List<Class> Classes { get; set; }

        public School(IEnumerable<Class> classes)
        {
            this.Classes = new List<Class>(classes);
        }

        public override string ToString()
        {
            return this.Classes.ToString();
        }
    }
}
