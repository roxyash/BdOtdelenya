using System;

namespace BdBegin.Windows
{
    public class StudentsClass
    {
        public StudentsClass(int id)
        {
            NumberStudents = id;
        }

        public int NumberStudents { get; }
        public int OrderNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDay { get; set; }
        public int Course { get; set; }
    }
}
