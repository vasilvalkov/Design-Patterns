using System.Collections.Generic;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core.Contracts
{
    public interface ISchoolDatabase
    {
        IDictionary<int, IStudent> Students { get; }

        IDictionary<int, ITeacher> Teachers { get; }
    }
}