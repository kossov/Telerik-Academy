namespace School.Interfaces
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string CourseName { get; }
        IList<IStudent> Students { get; }

        void Add(IStudent student);
        void Remove(IStudent student);
    }
}