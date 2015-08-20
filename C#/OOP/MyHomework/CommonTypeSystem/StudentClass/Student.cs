namespace Students
{
    using System;

    public class Student : ICloneable, IComparable<Student>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int SocialSecurityNumber { get; set; }
        public string Adress { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public int Course { get; set; }
        public University University { get; set; }
        public Faculty Faculty { get; set; }
        public Specialty Specialty { get; set; }

        public Student()
        {
            // TODO: Complete member initialization
        }
        public Student(string firstName, string middleName, string lastName, int ssn, int course, University uni, Faculty fac, Specialty spec)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SocialSecurityNumber = ssn;
            this.Course = course;
            this.University = uni;
            this.Faculty = fac;
            this.Specialty = spec;
        }
        public Student(string firstName, string middleName, string lastName, int ssn, string adress, string phone, string email, int course, University uni, Faculty fac, Specialty spec)
            : this(firstName, middleName, lastName, ssn, course, uni, fac, spec)
        {
            this.Adress = adress;
            this.MobilePhone = phone;
            this.Email = email;
        }

        public override bool Equals(object obj)
        {
            Student objAsStudent = obj as Student;
            if (Object.Equals(objAsStudent, null))
            {
                return false;
            }
            if (!Object.Equals(this.FirstName, objAsStudent.FirstName)
                || !Object.Equals(this.MiddleName, objAsStudent.MiddleName)
                || !Object.Equals(this.LastName, objAsStudent.LastName)
                || !Object.Equals(this.SocialSecurityNumber, objAsStudent.SocialSecurityNumber))
            {
                return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.MiddleName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.SocialSecurityNumber.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("\n{0} {1} {2}\nSSN:{3}\nAdress:{4}\nMobilePhone:{5}  Email:{6}\nUniversity:{7},Faculty:{8},Specialty:{9},Course:{10}\n"
                , this.FirstName
                , this.MiddleName
                , this.LastName
                , this.SocialSecurityNumber
                , this.Adress
                , this.MobilePhone
                , this.Email
                , this.University
                , this.Faculty
                , this.Specialty
                , this.Course);
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return firstStudent.Equals(secondStudent);
        }
        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !firstStudent.Equals(secondStudent);
        }

        public object Clone()
        {
            Student newStudent = new Student()
            {
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                LastName = this.LastName,
                SocialSecurityNumber = this.SocialSecurityNumber,
                Course = this.Course,
                University = this.University,
                Faculty = this.Faculty,
                Specialty = this.Specialty,
                Adress = this.Adress,
                Email = this.Email,
                MobilePhone = this.MobilePhone
            };
            return newStudent;
        }

        public int CompareTo(Student other)
        {
            if (this.FirstName.CompareTo(other.FirstName) != 0)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }
            if (this.MiddleName.CompareTo(other.MiddleName) != 0)
            {
                return this.MiddleName.CompareTo(other.MiddleName);
            }
            if (this.LastName.CompareTo(other.LastName) != 0)
            {
                return this.LastName.CompareTo(other.LastName);
            }
            if (this.SocialSecurityNumber.CompareTo(other.SocialSecurityNumber) != 0)
            {
                return this.SocialSecurityNumber.CompareTo(other.SocialSecurityNumber);
            }
            return 0;
        }
    }
}
