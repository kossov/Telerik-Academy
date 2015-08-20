namespace EMDL_LINQ
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private int age;

        public string FN { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public List<int> Marks { get; set; }
        public int GroupNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Wrong student age!");
                }
                this.age = value;
            }
        }


        public Student(string firstName, string lastName, int age)
        {
            this.Age = age;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public Student(string firstName, string lastName, int age,string facNum, string tel, string email, List<int> marks, int grpNum) : this(firstName,lastName,age)
        {
            this.FN = facNum;
            this.Tel = tel;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = grpNum;
        }


        public override string ToString()
        {
            return string.Format("{0} {1} {2}",this.Age,this.FirstName,this.LastName);
        }
    }
}
