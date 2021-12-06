using System;
using System.ComponentModel.DataAnnotations;

namespace APS.EFDataAccessLibrary.Models
{
    public class Usage : IEquatable<Usage>
    {
        [Key]
        public string Code { get; set; }

        public string Description { get; set; }

        public bool Equals(Usage other)
        {
            return other != null && Code == other.Code;
        }

        public override bool Equals(object obj) => Equals(obj as Usage);

        public override int GetHashCode() => (Code, Description).GetHashCode();
    }
}
