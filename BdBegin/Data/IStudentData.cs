using BdBegin.Models;
using System.Collections.Generic;

namespace BdBegin.Data
{
    public interface IStudentData
    {
        List<Student> GetAll();
        void Remove(int id);
        void Add(Student student);
        void Update(Student student);
        Student GetById(int id);
        List<Student> GetByGroup(string v);
    }
}