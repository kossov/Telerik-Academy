namespace Schools
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Class
    {
        public string Identifier { get; private set; }
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }

        public Class(string identifier, IEnumerable<Teacher> teachers, IEnumerable<Student> students)
        {
            this.Identifier = identifier;
            this.Teachers = new List<Teacher>(teachers);
            this.Students = new List<Student>(students);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("~Teachers~");
            result.Append(string.Join("\n",this.Teachers));
            result.AppendLine("\n~Students~");
            result.Append(string.Join("\n", this.Students));
            return result.ToString();
        }
    }
}
