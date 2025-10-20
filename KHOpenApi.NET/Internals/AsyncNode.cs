using System;
using System.Threading;
using System.Threading.Tasks;

namespace KHOpenApi.NET.Internals;

internal class AsyncNode(object[] objs) : IDisposable
{
    public readonly int IdentId = GetIdentId(objs);
    public Func<int, EventArgs, bool>? EventCallback;
    public bool EventReceived = false;
    public string Msg = string.Empty;

    public static int GetIdentId(object[] objs)
    {
        int id = 0;
        for (int i = 0; i < objs.Length; i++)
        {
            // null-safe and stable-ish combined hash
            int h = objs[i]?.GetHashCode() ?? 0;
            id = id * 31 + h;
        }
        return id;
    }

    public bool Set() => _eventWaitHandle.Set();

    public Task<bool> Wait(int millisecondsTimeout = -1)
    {
        return Task.Run(() =>
        {
            if (_disposed)
                return false;

            if (!_eventWaitHandle.WaitOne(millisecondsTimeout) && !EventReceived)
            {
                return false;
            }
            return true;
        });
    }

    private readonly ManualResetEvent _eventWaitHandle = new(false);

    private bool _disposed;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            _eventWaitHandle.Dispose();
        }
        _disposed = true;
    }
}
