using System;
using System.ComponentModel.DataAnnotations;

namespace APS.EFDataAccessLibrary.Models
{
    public class TaskTypesOfWork : IEquatable<TaskTypesOfWork>
    {
        [Key]
        public string Code { get; set; }

        public string Description { get; set; }

        public bool Equals(TaskTypesOfWork other)
        {
            return other != null && Code == other.Code;
        }

        public override bool Equals(object obj) => Equals(obj as TaskTypesOfWork);

        public override int GetHashCode() => (Code, Description).GetHashCode();
    }
}
