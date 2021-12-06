using System;
using System.ComponentModel.DataAnnotations;

namespace APS.EFDataAccessLibrary.Models
{
    public class Discipline : IEquatable<Discipline>
    {
        [Key]
        public string Code { get; set; }

        public char? CharCode { get; set; }

        public string Description { get; set; }

        public bool Equals(Discipline other)
        {
            return other != null && Code == other.Code;
        }

        public override bool Equals(object obj) => Equals(obj as Discipline);

        public override int GetHashCode() => (Code, CharCode, Description).GetHashCode();
    }
}
