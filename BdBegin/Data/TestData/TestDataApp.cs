using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdBegin.Data.TestData
{
    public class TestDataApp : IDataApp
    {
        public ISpecializationData Specializations { get; private set; }
        public IStudentData Students { get; private set; }
        public ITeacherData Teachers { get; private set; }
        public IProgressData Progress { get; private set; }
        public IDisciplineData Disciplines { get; private set; }

        public TestDataApp()
        {
            Specializations = new TestSpecializations();
            Students = new TestStudents();
            Teachers = new TestTeachers();
            Progress = new TestProgress(this);
            Disciplines = new TestDisciplines();
        }
    }
}
