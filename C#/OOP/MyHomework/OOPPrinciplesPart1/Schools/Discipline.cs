namespace Schools
{
    using System;

    public class Discipline
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length <= 1)
                {
                    throw new ArgumentException("Too short discipline name");
                }
                this.name = value;
            }
        }
        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Wrong value for NumberOfLectures");
                }
                this.numberOfLectures = value;
            }
        }
        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Wrong value for NumberOfExercises");
                }
                this.numberOfExercises = value;
            }
        }

        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}",this.Name,this.NumberOfLectures,this.NumberOfExercises);
        }
    }
}
