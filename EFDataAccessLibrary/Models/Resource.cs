using System;
using System.ComponentModel.DataAnnotations;

namespace APS.EFDataAccessLibrary.Models
{
    public class Resource : IEquatable<Resource>
    {
        [Key]
        public string Code { get; set; }

        public string Description { get; set; }

        public bool Equals(Resource other)
        {
            return other != null && Code == other.Code;
        }

        public override bool Equals(object obj) => Equals(obj as Resource);

        public override int GetHashCode() => (Code, Description).GetHashCode();
    }
}
