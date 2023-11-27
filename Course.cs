using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeSAEnrolment
{
    public class Course
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public decimal Cost { get; set; }

        public Course(string courseCode, string courseName, decimal cost)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            Cost = cost;
        }
    }
}
