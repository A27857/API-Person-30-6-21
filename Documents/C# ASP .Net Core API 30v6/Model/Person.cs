using System;
using System.Runtime.Serialization;

namespace API30v6.Models
{
    public class Person
    {   
        [IgnoreDataMember]
        public int Id { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [IgnoreDataMember]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string BirthPlace { get; set; }
    }
}