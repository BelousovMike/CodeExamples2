using DocumentFormat.OpenXml.Packaging;
using System.IO;

namespace APS.Domain.Interfaces
{
    public interface IWordDataReplacer
    {
        void ReplaceData(int taskId, WordprocessingDocument document);
    }
}
