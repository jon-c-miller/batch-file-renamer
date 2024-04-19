namespace ConsoleFileRenamer
{
    public class Controller
    {
        public Controller()
        {
            view = new(model);
        }

        readonly Model model = new();
        View view;

        public void ShowPrompt() => view.Prompt();

        public void HandleSelection(int choice) => view.HandleSelection(choice);
    }
}