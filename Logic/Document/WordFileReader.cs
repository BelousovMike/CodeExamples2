using APS.Domain.Interfaces;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.IO;

namespace APS.Core.Document
{
    public class WordFileReader : IWordFileReader
    {
        public WordprocessingDocument GetDocument(Stream stream)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "WordTemplate", "Template.docx");
            using var document = WordprocessingDocument.Open(path, false);
            var copy = document.Clone(stream, true) as WordprocessingDocument;
            return copy;
        }
    }
}
