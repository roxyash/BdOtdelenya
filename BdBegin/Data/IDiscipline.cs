using BdBegin.Models;
using System.Collections.Generic;

namespace BdBegin.Data
{
    public interface IDisciplineData
    {
        Discipline GetById(int disciplineId);
        List<Discipline> GetAll();
    }
}