using SchoolSystem.Framework.Core.Factories.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Factories
{
    public class SchoolFactory : ISchoolFactory
    {
        public Mark CreateMark(Subject subject, float value)
        {
            return new Mark(subject, value);
        }

        public Student CreateStudent(string firstName, string lastName, Grade grade)
        {
           return new Student(firstName, lastName, grade);
        }

        public ITeacher CreateTeacher(string firstName, string lastName, Subject subject)
        {
            return new Teacher(firstName, lastName, subject, this);
        }
    }
}
