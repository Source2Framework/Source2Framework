namespace Source2Framework
{
    using Source2Framework.Models;

    public static partial class SDK
    {
        public static void RunOnMainThread(Action callback)
        {
            using (SyncContextScope synchronizationContext = new SyncContextScope())
            {
                callback.Invoke();
            }
        }

        public static async Task RunOnMainThreadAsync(Func<Task> callback)
        {
            await new Func<Task>(async () =>
            {
                using (SyncContextScope synchronizationContext = new SyncContextScope())
                {
                    await callback.Invoke();
                }
            }).Invoke();
        }
    }
}
