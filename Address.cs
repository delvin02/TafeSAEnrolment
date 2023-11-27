using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeSAEnrolment
{
    public class Address
    {
        public string Number { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }

        public Address(string number, string street, string suburb, string postcode, string state)
        {
            Number = number;
            Street = street;
            Suburb = suburb;
            PostCode = postcode;
            State = state;
        }
    }
}
