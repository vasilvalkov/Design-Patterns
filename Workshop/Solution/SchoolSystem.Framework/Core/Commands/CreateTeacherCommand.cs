using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories.Contracts;
using SchoolSystem.Framework.Models.Enums;
using System.Collections.Generic;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private readonly ISchoolFactory schoolFactory;
        private readonly ISchoolDatabase schoolDatabase;
        private int currentTeacherId = 0;

        public CreateTeacherCommand(ISchoolFactory schoolFactory, ISchoolDatabase schoolDatabase)
        {
            this.schoolFactory = schoolFactory;
            this.schoolDatabase = schoolDatabase;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = this.schoolFactory.CreateTeacher(firstName, lastName, subject);
            this.schoolDatabase.Teachers.Add(this.currentTeacherId, teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {this.currentTeacherId++} was created.";
        }
    }
}
