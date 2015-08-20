namespace EMDL_LINQ.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ExtractStudentsWithTwoMarks_2_Extention
    {
        public static IEnumerable<Student> ExtractWithTwo2(this IEnumerable<Student> arr)
        {
            var allStudentsWithTwoMarks2 =
                from student in arr
                where (student.Marks.Count(x => x == 2) >= 2)
                select student;
            return allStudentsWithTwoMarks2;
        }
    }
}
