using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeSAEnrolment
{
    // inherits from Person
    public class Student : Person, IComparable<Student>, IEquatable<Student>
    {
        public int StudentId { get; set; }
        public string Program { get; set; }
        public DateTime DateRegistered { get; set; }
        private List<Enrollment> Enrollments { get; set; }


        public Student(int StudentId, string Name, string Email, string TelNum, string Program, DateTime DateRegistered) : base(Name, Email, TelNum)
        {
            this.StudentId = StudentId;
            this.Program = Program;
            this.DateRegistered = DateRegistered;
            this.Enrollments = new List<Enrollment>();
        }
        public int GetStudentId()
        {
            return StudentId;
        }
        public override int GetHashCode()
        {
            return Program.GetHashCode() ^ DateRegistered.GetHashCode();
        }

        public int CompareTo(Student other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.StudentId.CompareTo(other.StudentId);
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            Enrollments.Add(enrollment);
        }
        public static bool operator ==(Student x, Student y)
        {
            return x.StudentId == y?.StudentId;
        }

        public static bool operator !=(Student x, Student y)
        {
            return x.StudentId != y?.StudentId;
        }
        public bool Equals(Student other)
        {
            if (other == null)
                return false;

            // if Student class does not get passed in
            if (!(other is Student))
                return false;

            return this.StudentId == ((Student)other).StudentId;

        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Student);
        }

        public string StudentInfo
        {
            get
            {
                return $"Name: {Name}Email: {Email}TelNum: {TelNum}";
            }
        }

    }
}
