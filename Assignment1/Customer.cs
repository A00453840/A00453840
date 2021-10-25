using System;
using CsvHelper.Configuration.Attributes;

namespace Assignment1
{
    public class Customer
    {
            [Name("First Name")]
            public String FirstName { get; set; }
            [Name("Last Name")]
            public String LastName { get; set; }
            [Name("Street Number")]
            public String StreetNum { get; set; }
            public String Street { get; set; }
            public String City { get; set; }
            public String Province { get; set; }
            [Name("Postal Code")]
            public String PostalCode { get; set; }
            public String Country { get; set; }
            [Name("Phone Number")]
            public String PhoneNum { get; set; }
            [Name("email Address")]
            public String Email { get; set; }
    }
}
