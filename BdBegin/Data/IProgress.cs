using BdBegin.Models;
using System;
using System.Collections.Generic;

namespace BdBegin.Data
{
    public interface IProgressData
    {
        List<Progress> GetAllByStudentId(int id);
        void Remove(int id);
        List<Progress> GetFromToByStudentId(DateTime from, DateTime to, int id);
        void Add(int selectedScore, Discipline selectedDiscipline, Teacher selectedTeacher, DateTime date, int _studentId);
        void Update(Progress editProgress);
    }
}