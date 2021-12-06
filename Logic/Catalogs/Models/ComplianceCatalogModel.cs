using APS.EFDataAccessLibrary.Models;
using System.Collections.Generic;

namespace APS.Core.Catalog.Models
{
    public class ComplianceCatalogModel
    {
        public IEnumerable<Compliance> Compliances { get; set; }
    }
}
