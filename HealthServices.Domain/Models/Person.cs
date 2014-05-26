using System;
using System.Collections.Generic;

namespace HealthServices.Domain.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<VitalSign> VitalSigns { get; set; }
        public Address Address { get; set; }

    }
}
