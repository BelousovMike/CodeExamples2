using System;
using System.ComponentModel.DataAnnotations;

namespace APS.EFDataAccessLibrary.Models
{
    public class SystemCondition : IEquatable<SystemCondition>
    {
        [Key]
        public string Code { get; set; }

        public string Description { get; set; }

        public bool Equals(SystemCondition other)
        {
            return other != null && Code == other.Code;
        }

        public override bool Equals(object obj) => Equals(obj as SystemCondition);

        public override int GetHashCode() => (Code, Description).GetHashCode();
    }
}
