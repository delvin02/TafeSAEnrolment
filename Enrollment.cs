using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeSAEnrolment
{
    public class Enrollment
    {
        public DateTime DateEnrolled { get; set; }
        public string Grade { get; set; } 
        public string Semester { get; set; }
        public Course Course { get; set; }

        public Enrollment(DateTime dateEnrolled, string grade, string semester, Course course)
        {
            DateEnrolled = dateEnrolled;
            Grade = grade;
            Semester = semester;
            Course = course;
        }

        public void SetGrade(string grade)
        {
            Grade = grade;
        }
    }
}
