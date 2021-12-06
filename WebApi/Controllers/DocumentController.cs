using APS.Domain.Interfaces;
using APS.EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace APS.Web.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : Controller
    {
        [HttpGet("download-task-document/{taskId:int}")]
        public IActionResult DownloadTaskDocument(int taskId, [FromServices]IDocumentGenerator documentGenerator)
        {
            var file = documentGenerator.Generate(taskId);
            return File(file, "application/pdf");
        }

        [HttpPost("upload-task-data")]
        public IActionResult UploadTaskData([FromServices] IExcelParser excelParser, [FromBody] Stream fileStream)
        {
            var result = excelParser.Parse<APSTask>(fileStream);
            return Ok(result);
        }
    }
}
