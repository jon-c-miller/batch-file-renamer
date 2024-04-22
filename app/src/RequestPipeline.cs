using System.Collections.Concurrent;

namespace ConsoleFileRenamer
{
    public class RequestPipeline : IRequestReceiver
    {
        IRequestHandler handler;
        bool showLogs;

        readonly ConcurrentQueue<RequestIDs> pipeline = new();

        public void Initialize(IRequestHandler handler, bool showLogs)
        {
            this.handler = handler;
            this.showLogs = showLogs;
        }

        public void ProcessRequests()
        {
            while (pipeline.Count > 0)
            {
                pipeline.TryDequeue(out RequestIDs id);

                if (showLogs) ConsoleExtensions.PrintToConsole($"Processing id '{id}'...", true, true);
                handler.IHandleRequest(id);
            }
        }

        public void IQueueRequest(RequestIDs id)
        {
            pipeline.Enqueue(id);
            if (showLogs) ConsoleExtensions.PrintToConsole($"Received request {id}. Request queue has {pipeline.Count} requests.", true);
        }
    }

    public interface IRequestHandler
    {
        void IRelayRequest(RequestIDs id);
        bool IHandleRequest(RequestIDs id, params object[] data);
    }

    public interface IRequestReceiver
    {
        void IQueueRequest(RequestIDs id);
    }

    public enum RequestIDs
    {
        Null,
        PrintToConsole,
        ShowPrompt,
        HandleSelection,
        
    }
}