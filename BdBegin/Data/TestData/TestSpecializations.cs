using BdBegin.Models;
using BdBegin.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdBegin.Data.TestData
{
    public class TestSpecializations : ISpecializationData
    {
        private List<Specialization> _specializations;
        public TestSpecializations()
        {
            _specializations = new List<Specialization>
            {
                new Specialization { Id = 1, Title = "Программирование в компьютерных системах",NumberDeportament=1 },
                new Specialization { Id = 2, Title = "Реклама",NumberDeportament=2 },
                new Specialization { Id = 3, Title = "Земельно имщуественные отношения",NumberDeportament=3 },
                new Specialization { Id = 4, Title = "Прикладная информатика",NumberDeportament=1 },
                new Specialization { Id = 5, Title = "Программирование в компьютеных системах",NumberDeportament=2 },
            };
        }

        public List<Specialization> GetAll()
        {
            return _specializations;
        }
    }
}
