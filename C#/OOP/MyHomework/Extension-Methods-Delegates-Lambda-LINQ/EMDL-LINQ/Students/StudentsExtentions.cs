namespace EMDL_LINQ.Students
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public static class StudentsExtentions
    {
        public static IEnumerable onlyWithGroupNumber2LINQ(this List<Student> list)
        {
            var result =
            from student in list
            where (student.GroupNumber == 2)
            orderby student.FirstName
            select student;
            return result;
        }
    }
}
