using System;
using System.ComponentModel.DataAnnotations;

namespace APS.EFDataAccessLibrary.Models
{
    public class TacticsTypesOfWork : IEquatable<TacticsTypesOfWork>
    {
        [Key]
        public string Code { get; set; }

        public string Description { get; set; }

        public bool Equals(TacticsTypesOfWork other)
        {
            return other != null && Code == other.Code;
        }

        public override bool Equals(object obj) => Equals(obj as TacticsTypesOfWork);

        public override int GetHashCode() => (Code, Description).GetHashCode();
    }
}
