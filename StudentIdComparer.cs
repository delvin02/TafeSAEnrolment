using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeSAEnrolment
{
    public class StudentIdComparer : Comparer<Student>
    {
        private static StudentIdComparer instance = new StudentIdComparer();
        public static StudentIdComparer Instance { get { return instance; } }

        private StudentIdComparer() { }

        public override int Compare(Student x, Student y)
        {
            if (x == null && y == null) return 1;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.StudentId.CompareTo(y.StudentId);
        }
    }
}
