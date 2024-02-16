namespace FriendlyExceptions
{
    public class WorkerNotFoundException : Exception
    {
        public WorkerNotFoundException(Guid Id) : base($"Worker {Id} not found") { }
    }
}
