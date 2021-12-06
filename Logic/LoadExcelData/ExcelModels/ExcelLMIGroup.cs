using APS.EFDataAccessLibrary.Models;
using Ganss.Excel;

namespace APS.Core.LoadExcelData.ExcelModels
{
    internal class ExcelLMIGroup
    {
        [Column(Letter = "C")]
        public string Title { get; set; }

        public LMIGroup ToLMIGroup()
        {
            return new()
            {
                Title = this.Title
            };
        }
    }
}
