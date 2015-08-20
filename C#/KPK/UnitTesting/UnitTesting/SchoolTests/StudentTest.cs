namespace SchoolTest.StudentTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class StudentTests
    {
        private Student student;

        [TestInitialize]
        public void InitializeStudent()
        {
            this.student = new Student("Gogo", "Petrov", 23654);
        }

        [TestMethod]
        public void StudentCannotBeNullWhenInstantiated()
        {
            Assert.IsNotNull(this.student);
        }

        [TestMethod]
        public void StudentFirstNameCannotBeNullEmptyOrWhiteSpace()
        {
            Assert.IsNotNull(this.student.FirstName);
        }

        [TestMethod]
        public void StudentLastNameCannotBeNullEmptyOrWhiteSpace()
        {
            Assert.IsNotNull(this.student.LastName);
        }

        [TestMethod]
        public void StudentIDMustBeInRange()
        {
            Assert.IsFalse(this.student.ID < 10000 || this.student.ID > 99999);
        }
    }
}