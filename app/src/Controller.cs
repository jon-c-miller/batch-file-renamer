namespace ConsoleFileRenamer
{
    public class Controller : IRequestHandler
    {
        public Controller()
        {
            view = new(model);
        }

        readonly Model model = new();
        View view;

        public void ShowPrompt() => view.Prompt();

        public bool HandleSelection(int choice) => view.HandleSelection(choice);

        public void IRelayRequest(RequestIDs id)
        {
            ConsoleExtensions.PrintToConsole($"Relayed request {id}", true);
        }

        public bool IHandleRequest(RequestIDs id)
        {
            ConsoleExtensions.PrintToConsole($"Handled request {id}", true);
            return true;
        }
    }
}