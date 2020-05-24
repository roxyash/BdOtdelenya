using BdBegin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdBegin.Data.TestData
{
    public class TestStudents : IStudentData
    {
        private List<Student> _students;
        public TestStudents()
        {
            _students = new List<Student>
            {
                //  "ПКС-306" 
                new Student(1) { FirstName = "Иван", LastName = "Иванов", MidName = "Иванович", Address = "Пушкина", Course = 3, BirthDay = DateTime.Today, Group = "ПКС-306"},
                new Student(2) { FirstName = "Сергей", LastName = "Сергеев", MidName = "Сергеевич", Address = "Изумрудный", Course = 3, BirthDay = DateTime.Today, Group ="ПКС-306" },
                new Student(3) { FirstName = "Василий", LastName = "Смирнов", MidName = "Дмитреевич", Address = "Мерлина", Course = 3, BirthDay = DateTime.Today,Group ="ПКС-306"  },
                new Student(4) { FirstName = "Александр", LastName = "Собянин", MidName = "Владимирович", Address = "Кастомаровская набережная", Course = 3, BirthDay = DateTime.Today,Group ="ПКС-306" },
                new Student(5) { FirstName = "Владимир", LastName = "Затылкин", MidName = "Александрович", Address = "Проспект ленина", Course = 3, BirthDay = DateTime.Today,Group ="ПКС-306" },
                // "ЗИО-112"
                new Student(6) { FirstName = "Ангелина", LastName = "Кузнецова", MidName = "Алеексеевна", Address = "Южная", Course = 1, BirthDay = DateTime.Today,Group =  "ЗИО-112" },
                new Student(7) { FirstName = "Андрей", LastName = "Попов", MidName = "Васильевич", Address = "Нестерова", Course = 1, BirthDay = DateTime.Today,Group =  "ЗИО-112" },
                new Student(8) { FirstName = "Николай", LastName = "Петров", MidName = "Андреевич", Address = "Виноградова", Course = 1, BirthDay = DateTime.Today,Group =  "ЗИО-112" },
                new Student(9) { FirstName = "Илья", LastName = "Соколов", MidName = "Григорьевич", Address = "Хабаровская", Course = 1, BirthDay = DateTime.Today,Group =  "ЗИО-112" },
                new Student(10) { FirstName = "Ева", LastName = "Новикова", MidName = "Аркадьевна", Address = "Парковая", Course = 1, BirthDay = DateTime.Today,Group =  "ЗИО-112" },
                new Student(11) { FirstName = "Алина", LastName = "Козлова", MidName = "Михайловна", Address = "Карла Маркса", Course = 1, BirthDay = DateTime.Today,Group =  "ЗИО-112" },
                // "КС-201"
                new Student(12) { FirstName = "Семен", LastName = "Макаров", MidName = "Эльдарович", Address = "Вяземская", Course = 2, BirthDay = DateTime.Today,Group = "КС-201" },
                new Student(13) { FirstName = "Григорий", LastName = "Антонов", MidName = "Сергеевич", Address = "Нахимова", Course = 2, BirthDay = DateTime.Today,Group = "КС-201" },
                new Student(14) { FirstName = "Геннадий", LastName = "Горин", MidName = "Максимович", Address = "Главная", Course = 2, BirthDay = DateTime.Today,Group = "КС-201" },
                new Student(15) { FirstName = "Максим", LastName = "Ковалев", MidName = "Тарасович", Address = "Летняя", Course = 2, BirthDay = DateTime.Today,Group = "КС-201" },
                new Student(16) { FirstName = "Марк", LastName = "Комаров", MidName = "Александрович", Address = "Горького", Course = 2, BirthDay = DateTime.Today,Group = "КС-201" },
                // "ИБ-409"
                new Student(17) { FirstName = "Полина", LastName = "Баранова", MidName = "Анатольевна", Address = "Снайперская", Course = 4, BirthDay = DateTime.Today,Group = "ИБ-409" },
                new Student(18) { FirstName = "Кирилл", LastName = "Саипов", MidName = "Андреевич", Address = "Щелковская", Course = 4, BirthDay = DateTime.Today,Group = "ИБ-409" },
                new Student(19) { FirstName = "Богдан", LastName = "Беннер", MidName = "Миронович", Address = "Митрофанова", Course = 4, BirthDay = DateTime.Today,Group = "ИБ-409" },
                new Student(20) { FirstName = "Влада", LastName = "Матвеева", MidName = "Олеговна", Address = "Новый свет", Course = 4, BirthDay = DateTime.Today,Group = "ИБ-409" },
                new Student(21) { FirstName = "Ксения", LastName = "Филатова", MidName = "Александровна", Address = "Таганская", Course = 4, BirthDay = DateTime.Today,Group = "ИБ-409" },
                // "Р-113"
                new Student(22) { FirstName = "Азат", LastName = "Ямалтединов", MidName = "Владимирович", Address = "Московский бульвар", Course = 1, BirthDay = DateTime.Today,Group = "Р-113" },
                new Student(23) { FirstName = "Савелий", LastName = "Жуков", MidName = "Денисович", Address = "Казакова", Course = 1, BirthDay = DateTime.Today,Group = "Р-113" },
                new Student(24) { FirstName = "Денис", LastName = "Гусев", MidName = "Олегович", Address = "Пресненская набережная", Course = 1, BirthDay = DateTime.Today,Group = "Р-113" },
                new Student(25) { FirstName = "Кристина", LastName = "Тихонова", MidName = "Альбертовна", Address = "Третьяка", Course = 1, BirthDay = DateTime.Today,Group = "Р-113" },
                new Student(26) { FirstName = "Данил", LastName = "Савельев", MidName = "Гаврилович", Address = "Мельникова", Course = 1, BirthDay = DateTime.Today,Group = "Р-113" },
                //ИБ-209
                new Student(27) { FirstName = "Тимофей", LastName = "Ефимов", MidName = "Назарович", Address = "Быкова", Course = 2, BirthDay = DateTime.Today,Group = "ИБ-209" },
                new Student(28) { FirstName = "Екатерина", LastName = "Простомолотова", MidName = "Абрамовна", Address = "Исаева", Course = 2, BirthDay = DateTime.Today,Group = "ИБ-209" },
                new Student(29) { FirstName = "Тамара", LastName = "Лазарева", MidName = "Родионовна", Address = "Климова", Course = 2, BirthDay = DateTime.Today,Group = "ИБ-209" },
                new Student(30) { FirstName = "Валерий", LastName = "Жмышенко", MidName = "Альбертович", Address = "Малинина", Course = 2, BirthDay = DateTime.Today,Group = "ИБ-209" },
                new Student(31) { FirstName = "Прохор", LastName = "Кудрявцев", MidName = "Акимович", Address = "Горбунова", Course = 2, BirthDay = DateTime.Today,Group = "ИБ-209" },



            };
        }

        public void Add(Student student)
        {
           var id = _students.Max(s => s.Id) + 1;
            _students.Add(new Student(id) { FirstName = student.FirstName, LastName = student.LastName, MidName = student.MidName, Address = student.Address, Course = student.Course});
        }

        public List<Student> GetAll()
        {
            return _students;
        }

        public List<Student> GetByGroup(string groupName)
        {
            return _students.Where(s => s.Group.Equals(groupName)).ToList();
        }

        public Student GetById(int id)
        {
            return _students.First(s => s.Id == id);
        }

        public void Remove(int id)
        {
            var std = _students.First(s => s.Id == id);
            _students.Remove(std);
        }

        public void Update(Student student)
        {
            var std = _students.First(s => s.Id == student.Id);
            std.FirstName = student.FirstName;
            std.LastName = student.LastName;
            std.MidName = student.MidName;
            std.Address = student.Address;
            std.Course = student.Course;
        }
    }
}
