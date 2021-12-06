using APS.EFDataAccessLibrary.Models;
using System.Collections.Generic;

namespace APS.Core.Catalog.Models
{
    public class UsageCatalogModel
    {
        public IEnumerable<Usage> Usages { get; set; }
    }
}
