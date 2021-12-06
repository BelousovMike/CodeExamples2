using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APS.EFDataAccessLibrary.Models
{
    public class LMIItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public LMIGroup LMIGroup { get; set; }
        public ICollection<APSTask> Tasks { get; set; }
    }
}
