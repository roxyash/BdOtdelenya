using BdBegin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdBegin.Data.TestData
{
    public class TestDisciplines : IDisciplineData
    {
        private List<Discipline> _disciplines;
        public TestDisciplines()
        {
            _disciplines = new List<Discipline>
            {
                new Discipline { Id = 1, Name = "Программирование" },
                new Discipline { Id = 2, Name = "Английский" },
                new Discipline { Id = 3, Name = "Русский" },
                new Discipline { Id = 4, Name = "Математика" },
                new Discipline { Id = 5, Name = "Физкультура" },
            };
        }

        public List<Discipline> GetAll()
        {
            return _disciplines;
        }

        public Discipline GetById(int disciplineId)
        {
            return _disciplines.First(d => d.Id == disciplineId);
        }
    }
}
