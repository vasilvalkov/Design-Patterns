using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        private readonly ISchoolDatabase schoolDatabase;

        public StudentListMarksCommand(ISchoolDatabase schoolDatabase)
        {
            this.schoolDatabase = schoolDatabase;
        }

        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            var student = this.schoolDatabase.Students[studentId];
            return student.ListMarks();
        }
    }
}
