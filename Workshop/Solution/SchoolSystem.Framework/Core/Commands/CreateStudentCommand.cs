using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories.Contracts;
using SchoolSystem.Framework.Models.Enums;
using System.Collections.Generic;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private static int currentStudentId = 0;
        private readonly ISchoolFactory schoolFactory;
        private readonly ISchoolDatabase schoolDatabase;

        public CreateStudentCommand(ISchoolFactory schoolFactory, ISchoolDatabase schoolDadtabase)
        {
            this.schoolFactory = schoolFactory;
            this.schoolDatabase = schoolDadtabase;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = this.schoolFactory.CreateStudent(firstName, lastName, grade);
            this.schoolDatabase.Students.Add(currentStudentId, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {currentStudentId++} was created.";
        }
    }
}
