using System;

namespace BdBegin.Models
{
    public class Student
    {
        public Student(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public int OrderNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDay { get; set; }
        public int Course { get; set; }
        public string Group {get;set;}

        public double AbsScore { get; set; }
    }
}
