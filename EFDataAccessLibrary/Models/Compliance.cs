using System;
using System.ComponentModel.DataAnnotations;

namespace APS.EFDataAccessLibrary.Models
{
    public class Compliance : IEquatable<Compliance>
    {
        [Key]
        public string Code { get; set; }

        public string Description { get; set; }

        public bool Equals(Compliance other)
        {
            return other != null && Code == other.Code;
        }

        public override bool Equals(object obj) => Equals(obj as Compliance);

        public override int GetHashCode() => (Code, Description).GetHashCode();
    }
}
