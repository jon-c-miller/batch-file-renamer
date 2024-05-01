namespace ConsoleFileRenamer
{
    public class BatchFileRenamer
    {
        public void Run()
        {
            RequestPipeline pipeline = new();
            RequestHandler handler = new(pipeline);
            pipeline.Initialize(handler, false);
            handler.IHandleRequest(RequestIDs.ChangeState, States.UserPrompt);

            // loop until user chooses to quit
            while (handler.Continue) 
            {
                handler.Process();
                pipeline.Process();
            }

            // final message before exit
            ConsoleExtensions.PrintToConsole("Thank you for using the file renaming utility. Have a nice day!", true);
            ConsoleExtensions.PrintToConsole("Press any key to quit...", true);
            Console.ReadKey();
        }
    }
}