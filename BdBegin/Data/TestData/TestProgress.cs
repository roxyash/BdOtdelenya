using BdBegin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdBegin.Data.TestData
{
    public class TestProgress : IProgressData
    {
        private readonly TestDataApp _testDataApp;
        private List<Models.Progress> _progresses;
        public TestProgress(TestDataApp testDataApp)
        {
            _progresses = new List<Models.Progress>
            {
                new Models.Progress { DateOfComplition = DateTime.Today, Id = 1, StudentId = 1,  DisciplineId = 1, TeacherId = 1, Score = 2 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 2, StudentId = 2,  DisciplineId = 2, TeacherId = 2, Score = 3 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 3, StudentId = 3,  DisciplineId = 3, TeacherId = 3, Score = 4 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 4, StudentId = 4,  DisciplineId = 4, TeacherId = 4, Score = 5 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 5, StudentId = 5,  DisciplineId = 5, TeacherId = 5, Score = 2 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 6, StudentId = 6,  DisciplineId = 1, TeacherId = 1, Score = 3 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 7, StudentId = 7,  DisciplineId = 2, TeacherId = 2, Score = 4 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 8, StudentId = 8,  DisciplineId = 3, TeacherId = 3, Score = 5 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 9, StudentId = 9,  DisciplineId = 4, TeacherId = 4, Score = 2 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 10, StudentId = 10,  DisciplineId = 5, TeacherId = 5, Score = 3 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 11, StudentId = 11,  DisciplineId = 1, TeacherId = 1, Score = 4 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 12, StudentId = 12,  DisciplineId = 2, TeacherId = 2, Score = 5 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 13, StudentId = 13,  DisciplineId = 3, TeacherId = 3, Score = 2 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 14, StudentId = 14,  DisciplineId = 4, TeacherId = 4, Score = 3 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 15, StudentId = 15,  DisciplineId = 5, TeacherId = 5, Score = 4 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 16, StudentId = 16,  DisciplineId = 1, TeacherId = 1, Score = 5 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 17, StudentId = 17,  DisciplineId = 2, TeacherId = 2, Score = 2 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 18, StudentId = 18,  DisciplineId = 3, TeacherId = 3, Score = 3 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 19, StudentId = 19,  DisciplineId = 4, TeacherId = 4, Score = 4 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 20, StudentId = 20,  DisciplineId = 5, TeacherId = 5, Score = 5 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 21, StudentId = 21,  DisciplineId = 1, TeacherId = 1, Score = 2 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 22, StudentId = 22,  DisciplineId = 2, TeacherId = 2, Score = 3 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 23, StudentId = 23,  DisciplineId = 3, TeacherId = 3, Score = 4 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 24, StudentId = 24,  DisciplineId = 4, TeacherId = 4, Score = 5 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 25, StudentId = 25,  DisciplineId = 5, TeacherId = 5, Score = 2 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 26, StudentId = 26,  DisciplineId = 1, TeacherId = 1, Score = 3 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 27, StudentId = 27,  DisciplineId = 2, TeacherId = 2, Score = 4 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 28, StudentId = 28,  DisciplineId = 3, TeacherId = 3, Score = 5 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 29, StudentId = 29,  DisciplineId = 4, TeacherId = 4, Score = 2 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 30, StudentId = 30,  DisciplineId = 5, TeacherId = 5, Score = 3 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 31, StudentId = 31,  DisciplineId = 1, TeacherId = 1, Score = 4 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 32, StudentId = 1,  DisciplineId = 2, TeacherId = 2, Score = 5},
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 33, StudentId = 2,  DisciplineId = 3, TeacherId = 3, Score = 2 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 34, StudentId = 3,  DisciplineId = 4, TeacherId = 4, Score = 3 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 35, StudentId = 4,  DisciplineId = 5, TeacherId = 5, Score = 4 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 36, StudentId = 5,  DisciplineId = 1, TeacherId = 1, Score = 5 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 37, StudentId = 6,  DisciplineId = 2, TeacherId = 2, Score = 2 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 38, StudentId = 7,  DisciplineId = 3, TeacherId = 3, Score = 3 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 39, StudentId = 8,  DisciplineId = 4, TeacherId = 4, Score = 4 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 40, StudentId = 9,  DisciplineId = 5, TeacherId = 5, Score = 5 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 41, StudentId = 10,  DisciplineId = 1, TeacherId = 1, Score =2 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 42, StudentId = 11,  DisciplineId = 2, TeacherId = 2, Score = 3 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 43, StudentId = 12,  DisciplineId = 3, TeacherId = 3, Score = 4 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 44, StudentId = 13,  DisciplineId = 4, TeacherId = 4, Score = 5 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 45, StudentId = 14,  DisciplineId = 5, TeacherId = 5, Score = 2 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 46, StudentId = 15,  DisciplineId = 1, TeacherId = 1, Score = 3 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 47, StudentId = 16,  DisciplineId = 2, TeacherId = 2, Score = 4 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 48, StudentId = 17,  DisciplineId = 3, TeacherId = 3, Score = 5 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 49, StudentId = 18,  DisciplineId = 4, TeacherId = 4, Score = 2 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 50, StudentId = 19,  DisciplineId = 5, TeacherId = 5, Score = 3 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 51, StudentId = 20,  DisciplineId = 1, TeacherId = 1, Score = 4 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 52, StudentId = 21,  DisciplineId = 2, TeacherId = 2, Score = 5 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 53, StudentId = 22,  DisciplineId = 3, TeacherId = 3, Score = 2 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 54, StudentId = 23,  DisciplineId = 4, TeacherId = 4, Score = 3 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 55, StudentId = 24,  DisciplineId = 5, TeacherId = 5, Score = 4 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 56, StudentId = 25,  DisciplineId = 1, TeacherId = 1, Score = 5 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 57, StudentId = 26,  DisciplineId = 2, TeacherId = 2, Score = 2 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 58, StudentId = 27,  DisciplineId = 3, TeacherId = 3, Score = 3 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 59, StudentId = 28,  DisciplineId = 4, TeacherId = 4, Score = 4 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 60, StudentId = 29,  DisciplineId = 5, TeacherId = 5, Score = 5 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 61, StudentId = 30,  DisciplineId = 1, TeacherId = 1, Score = 2 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 62, StudentId = 31,  DisciplineId = 2, TeacherId = 2, Score = 3 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 63, StudentId = 32,  DisciplineId = 3, TeacherId = 3, Score = 4 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 64, StudentId = 33,  DisciplineId = 4, TeacherId = 4, Score = 5 },
                new Models.Progress { DateOfComplition = DateTime.Today,Id = 65, StudentId = 34,  DisciplineId = 5, TeacherId = 5, Score = 2 },

            };
            this._testDataApp = testDataApp;
        }

        public void Add(int selectedScore, Discipline selectedDiscipline, Teacher selectedTeacher, DateTime date, int studentId)
        {
            var id = _progresses.Max(p => p.Id) + 1;
            var prog = new Progress
            {
                Id = id,
                StudentId = studentId,
                Discipline = selectedDiscipline,
                DisciplineId = selectedDiscipline.Id,
                Score = selectedScore,
                Teacher = selectedTeacher,
                TeacherId = selectedTeacher.Id,
                DateOfComplition = date
            };
            _progresses.Add(prog);
        }

        public List<Models.Progress> GetAllByStudentId(int id)
        {
            var prs = _progresses.Where(p => p.StudentId == id).ToList();
            var student = _testDataApp.Students.GetById(id);
            //var discpl = _testDataApp.Disciplines.GetById(prs.First().DisciplineId);
            //var teacher = _testDataApp.Teachers.GetById(prs.First().TeacherId);

            for (int i = 0; i < prs.Count; i++)
            {
                prs[i].Student = student;
                prs[i].Discipline = _testDataApp.Disciplines.GetById(prs[i].DisciplineId);
                prs[i].Teacher = _testDataApp.Teachers.GetById(prs[i].TeacherId);
            }
            return prs;
        }

        public List<Progress> GetFromToByStudentId(DateTime from, DateTime to, int studentId)
        {
            return _progresses.Where(p => p.StudentId == studentId
                                    && (p.DateOfComplition >= from && p.DateOfComplition <= to)).ToList();
        }

        public void Remove(int id)
        {
          var progress = _progresses.First(p => p.Id == id);
            _progresses.Remove(progress);
        }

        public void Update(Progress editProgress)
        {
            return;
        }
    }
}
