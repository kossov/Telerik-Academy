namespace Schools
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Teacher : People
    {
        private string name;

        public List<Discipline> Disciplines { get; set; }

        public override string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length <= 3)
                {
                    throw new ArgumentException("Too short Teacher name");
                }
                this.name = value;
            }
        }

        public Teacher(string name, IEnumerable<Discipline> disciplines)
        {
            this.Disciplines = new List<Discipline>(disciplines);
            this.Name = name;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(this.Name);
            result.AppendLine("  ~Disciplines~");
            result.AppendLine(string.Join("  \n", this.Disciplines));
            result.AppendLine();
            return result.ToString();
        }
    }
}
