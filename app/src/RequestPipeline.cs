using System.Collections.Concurrent;

namespace ConsoleFileRenamer
{
    public class RequestPipeline
    {
        public RequestPipeline(IRequestHandler handler, bool showLogs)
        {
            this.handler = handler;
            this.showLogs = showLogs;
        }

        readonly IRequestHandler handler;
        readonly bool showLogs;

        readonly ConcurrentQueue<RequestIDs> pipeline = new();

        public void QueueRequest(RequestIDs id)
        {
            pipeline.Enqueue(id);
            if (showLogs) ConsoleExtensions.PrintToConsole($"Queued request {id}. Request queue has {pipeline.Count} requests.", true);
        }

        public void HandleRequests()
        {
            while (pipeline.Count > 0)
            {
                pipeline.TryDequeue(out RequestIDs id);

                if (showLogs) ConsoleExtensions.PrintToConsole($"Processing id '{id}'...", true, true);
                handler.IHandleRequest(id);
            }
        }
    }

    public interface IRequestHandler
    {
        void IRelayRequest(RequestIDs id);
        bool IHandleRequest(RequestIDs id);
    }

    public enum RequestIDs
    {
        Null,

    }
}