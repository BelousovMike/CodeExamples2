using APS.EFDataAccessLibrary.Models;
using Ganss.Excel;

namespace APS.Core.LoadExcelData.ExcelModels
{
    internal class ExcelLMI
    {
        [Column(Letter = "A")]
        public int Id { get; set; }

        [Column(Letter = "B")]
        public string Title { get; set; }

        public LMIItem ToLMIItem()
        {
            return new()
            {
                Id = this.Id,
                Title = this.Title
            };
        }
    }
}
