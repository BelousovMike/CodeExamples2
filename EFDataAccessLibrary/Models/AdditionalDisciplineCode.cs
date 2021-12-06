using System;
using System.ComponentModel.DataAnnotations;

namespace APS.EFDataAccessLibrary.Models
{
    public class AdditionalDisciplineCode : IEquatable<AdditionalDisciplineCode>
    {
        [Key]
        public string Code1 { get; set; }

        public string Code2 { get; set; }

        public string Description { get; set; }

        public bool Equals(AdditionalDisciplineCode other)
        {
            return other != null && Code1 == other.Code1;
        }

        public override bool Equals(object obj) => Equals(obj as AdditionalDisciplineCode);

        public override int GetHashCode() => (Code1, Code2, Description).GetHashCode();
    }
}
