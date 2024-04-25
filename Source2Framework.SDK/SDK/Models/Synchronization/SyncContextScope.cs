namespace Source2Framework.Models
{
    public class SyncContextScope : IDisposable
    {
        private static SynchronizationContext _sourceContext = new SourceSynchronizationContext();

        private SynchronizationContext? _oldContext;

        public SyncContextScope()
        {
            _oldContext = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(_sourceContext);
        }

        public void Dispose()
        {
            if (_oldContext != null)
            {
                SynchronizationContext.SetSynchronizationContext(_oldContext);
            }
        }
    }
}
