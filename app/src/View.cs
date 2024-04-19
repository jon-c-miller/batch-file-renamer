namespace ConsoleFileRenamer
{
    public class View
    {
        public View(Model model)
        {
            this.model = model;
        }

        Model model;

        public void Prompt()
        {
            Console.Clear();
            ConsoleExtensions.PrintToConsole(model.GetMainMenuText());
        }
    }
}