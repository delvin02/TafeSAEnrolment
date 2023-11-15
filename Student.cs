using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeSAEnrolment
{
    public class Student
    {
        public string Program { get; set; }
        public DateTime DateRegistered { get; set; }

        public override int GetHashCode()
        {
            return Program.GetHashCode() ^ DateRegistered.GetHashCode();
        }
    }
}
