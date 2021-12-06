using DocumentFormat.OpenXml.Packaging;
using System.IO;

namespace APS.Domain.Interfaces
{
    public interface IWordFileReader
    {
        WordprocessingDocument GetDocument(Stream stream);
    }
}
