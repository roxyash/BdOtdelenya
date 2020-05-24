using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdBegin.Data
{
    public interface IDataApp
    {
        ISpecializationData Specializations {get; }
        IStudentData Students { get; }
        ITeacherData Teachers { get; }
        IProgressData Progress { get; }
        IDisciplineData Disciplines { get; }
    }
}
