namespace ConsoleFileRenamer
{
    public class BatchFileRenamer
    {
        public void Run()
        {
            Controller controller = new();

            // loop until user chooses to quit
            bool continueRenaming = true;
            while (continueRenaming)
            {
                controller.ShowPrompt();

                string input = Console.ReadLine();
            }
        }
    }
}