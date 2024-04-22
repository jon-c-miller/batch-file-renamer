namespace ConsoleFileRenamer
{
    public class BatchFileRenamer
    {
        public void Run()
        {
            RequestPipeline pipeline = new();
            Controller controller = new(pipeline);
            pipeline.Initialize(controller, false);

            // loop until user chooses to quit
            bool continueRenaming = true;
            while (continueRenaming)
            {
                controller.IHandleRequest(RequestIDs.ShowPrompt);

                pipeline.ProcessRequests();

                var input = Console.ReadLine();

                // filter out non-integer input
                if (!int.TryParse(input, out int choice)) continue;

                continueRenaming = controller.IHandleRequest(RequestIDs.HandleSelection, choice);

                pipeline.ProcessRequests();
            }
        }
    }
}