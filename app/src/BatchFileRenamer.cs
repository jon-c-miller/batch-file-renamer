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

                var input = Console.ReadLine();

                // filter out non-integer input
                if (!int.TryParse(input, out int choice)) continue;

                continueRenaming = controller.HandleSelection(choice);
            }
        }
    }
}