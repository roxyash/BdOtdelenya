using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdBegin.Models
{
    public class Progress
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int Score { get; set; }

        public DateTime DateOfComplition { get; set; }
    }
}
