using BdBegin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdBegin.Data.TestData
{
    public class TestTeachers : ITeacherData
    {
        private List<Teacher> _teachers;
        public TestTeachers()
        {
            _teachers = new List<Teacher>
            {
                new Teacher { Id = 1, FirstName = "Иван", LastName = "Голунов", MiddleName="Владимироваич"},
                new Teacher { Id = 2, FirstName = "Петр", LastName = "Иванов",MiddleName="Владимироваич"},
                new Teacher { Id = 3, FirstName = "Дмитрий", LastName = "Петров",MiddleName="Владимироваич" },
                new Teacher { Id = 4, FirstName = "Владимир", LastName = "Сидоров",MiddleName="Владимироваич" },
                new Teacher { Id = 5, FirstName = "Александр", LastName = "Смирнов",MiddleName="Владимироваич" },
            };

        }

        public List<Teacher> GetAll()
        {
            return _teachers;
        }

        public Teacher GetById(int teacherId)
        {
            return _teachers.First(t => t.Id == teacherId);
        }
    }
}
