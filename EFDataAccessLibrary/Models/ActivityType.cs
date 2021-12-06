using System;
using System.ComponentModel.DataAnnotations;

namespace APS.EFDataAccessLibrary.Models
{
    public class ActivityType : IEquatable<ActivityType>
    {
        [Key]
        public string Code { get; set; }

        public string Description { get; set; }

        public bool Equals(ActivityType other)
        {
            return other != null && Code == other.Code;
        }

        public override bool Equals(object obj) => Equals(obj as ActivityType);

        public override int GetHashCode() => (Code, Description).GetHashCode();
    }
}
