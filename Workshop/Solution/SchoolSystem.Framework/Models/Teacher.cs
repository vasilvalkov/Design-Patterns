using System;

using SchoolSystem.Framework.Models.Abstractions;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Core.Factories.Contracts;

namespace SchoolSystem.Framework.Models
{
    public class Teacher : Person, ITeacher
    {
        public const int MaxStudentMarksCount = 20;
        private readonly ISchoolFactory schoolFactory;

        public Teacher(string firstName, string lastName, Subject subject, ISchoolFactory schoolFactory)
            : base(firstName, lastName)
        {
            this.Subject = subject;
            this.schoolFactory = schoolFactory;
        }

        public Subject Subject { get; set; }

        public void AddMark(IStudent student, float mark)
        {
            if (student.Marks.Count >= MaxStudentMarksCount)
            {
                throw new ArgumentException($"The student's marks count exceed the maximum count of {MaxStudentMarksCount} marks");
            }

            var newMark = this.schoolFactory.CreateMark(this.Subject, mark);
            student.Marks.Add(newMark);
        }
    }
}
