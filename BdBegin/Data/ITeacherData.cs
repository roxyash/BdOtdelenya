using BdBegin.Models;
using System.Collections.Generic;

namespace BdBegin.Data
{
    public interface ITeacherData
    {
       Teacher GetById(int teacherId);
        List<Teacher> GetAll();
    }
}