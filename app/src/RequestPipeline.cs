using System.Collections.Concurrent;

namespace ConsoleFileRenamer
{
    public class RequestPipeline : IRequestReceiver
    {
        IRequestHandler? handler;
        bool showLogs;

        readonly ConcurrentQueue<Request> pipeline = new();

        public void Initialize(IRequestHandler handler, bool showLogs)
        {
            this.handler = handler;
            this.showLogs = showLogs;
        }

        public void Process()
        {
            while (pipeline.Count > 0)
            {
                pipeline.TryDequeue(out Request? request);

                if (request != null)
                {
                    if (showLogs) ConsoleExtensions.PrintToConsole($"Processing id '{request}'...", true, true);
                    handler?.IHandleRequest(request.ID, request.Data);
                }
            }
        }

        public void IQueueRequest(RequestIDs id, params object[] data)
        {
            pipeline.Enqueue(new(id, data));
            if (showLogs) ConsoleExtensions.PrintToConsole($"Received request {id}. Request queue has {pipeline.Count} requests.", true);
        }
    }

    public class Request(RequestIDs id, params object[] data)
    {
        public RequestIDs ID { get => id; set => id = value; }
        public object[] Data { get => data; set => data = value; }
    }

    public interface IRequestHandler
    {
        void IHandleRequest(RequestIDs id, params object[] data);
    }

    public interface IRequestReceiver
    {
        void IQueueRequest(RequestIDs id, params object[] data);
    }

    public enum RequestIDs
    {
        Null,
        DisplayMenu,
        DisplayCompletion,
    }
}