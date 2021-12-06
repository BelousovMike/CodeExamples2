namespace APS.Domain.Interfaces
{
    public interface IDocumentGenerator
    {
        byte[] Generate(int taskId);
    }
}
