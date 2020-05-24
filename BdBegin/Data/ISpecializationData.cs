using BdBegin.Models;
using System.Collections.Generic;

namespace BdBegin.Data
{
    public interface ISpecializationData
    {
        List<Specialization> GetAll();
    }
}