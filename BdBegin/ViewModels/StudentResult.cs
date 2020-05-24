using BdBegin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdBegin.ViewModels
{
    public class StudentResult
    {
        public Student  Student { get; set; }
        public int OrderNumber { get; set; }
        public string FirstName => Student.FirstName;
        public string LastName => Student.LastName;
        public string MidName => Student.MidName;
        public string Group => Student.Group;
        
        public List<Models.Progress> Progresses { get; set; }
        public double AbsScore => GetAbsScore();

        private double GetAbsScore()
        {
            double akk = 0;
            foreach (var prog in Progresses)
            {
                akk += prog.Score;
                
            }
            return akk / Progresses.Count;

        }

        public int CountFives => Progresses.Count(p => p.Score == 5);

        public int CountFoures => Progresses.Count(p => p.Score == 4);
        public int CountFivesAndFoures => CountFives + CountFoures;
        public int CountThrees => Progresses.Count(p => p.Score == 3);

        public int CountThreesAndFouresAndFives => CountFives + CountFoures + CountThrees;

        public int CountTwos => Progresses.Count(p => p.Score == 2);
    }
}
