using Persistence;

namespace Core.Tests.Common
{
    public class TestCommandBase
    {
        protected readonly WorkerDbContext Context;

        public TestCommandBase() => Context = CoreContextFactory.Create();

        public void Dispose() => CoreContextFactory.Destroy(Context);
    }
}
