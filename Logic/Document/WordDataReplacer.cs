using APS.Domain.Interfaces;
using APS.EFDataAccessLibrary;
using DocumentFormat.OpenXml.Packaging;

namespace APS.Core.Document
{
    public class WordDataReplacer : IWordDataReplacer
    {
        private readonly ApplicationContext _dbContext;

        public WordDataReplacer(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void ReplaceData(int taskId, WordprocessingDocument document)
        {
            /*var task = */FindTaskById(taskId);
            ReplaceDataDocument(document);
        }

        private void FindTaskById(int taskId)
        {

        }

        private void ReplaceDataDocument(/*Task task,*/ WordprocessingDocument document)
        {
        }
    }
}
