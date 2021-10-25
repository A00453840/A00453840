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
            [Name("Street")]
            public String Street { get; set; }
            [Name("City")]
            public String City { get; set; }
            [Name("Province")]
            public String Province { get; set; }
            [Name("Postal Code")]
            public String PostalCode { get; set; }
            [Name("Country")]
            public String Country { get; set; }
            [Name("Phone Number")]
            public String PhoneNum { get; set; }
            [Name("email Address")]
            public String Email { get; set; }
    }
}
