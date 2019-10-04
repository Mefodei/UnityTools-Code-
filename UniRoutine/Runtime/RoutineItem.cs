namespace UniTools.UniRoutine.Runtime
{
    using UniGreenModules.UniCore.Runtime.Common;
    
    public struct RoutineItem
    {
        public DisposableAction Disposable;
        public UniRoutineTask   Task;

        public bool MoveNext()
        {
            return Task.MoveNext();
        }

        public void Release()
        {
            Task.Dispose();
            Disposable?.Release();
        }
    }
}