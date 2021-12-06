using APS.Domain.Interfaces;
using Doc.Interfaces;
using Serilog;
using System.IO;

namespace APS.Core.Document
{
    public class DocumentGenerator : IDocumentGenerator
    {
        private const string _inputFileType = ".docx";
        private readonly IPdfConverter _pdfConverter;
        private readonly IWordFileReader _fileReader;
        private readonly IWordDataReplacer _dataReplacer;
        private readonly ILogger _logger;

        public DocumentGenerator(IPdfConverter pdfConverter,
            IWordFileReader fileReader,
            IWordDataReplacer dataReplacer,
            ILogger logger)
        {
            _pdfConverter = pdfConverter;
            _fileReader = fileReader;
            _dataReplacer = dataReplacer;
            _logger = logger;
        }

        public byte[] Generate(int taskId)
        {
            using var stream = new MemoryStream();
            _logger.Information($"Start generation document for Task with Id = {taskId}");
            using var document = _fileReader.GetDocument(stream);
            _dataReplacer.ReplaceData(taskId, document);
            var documentBytes = _pdfConverter.ConvertToPdf(_inputFileType, stream);
            _logger.Information("Generate document success");
            return documentBytes;
        }
    }
}
