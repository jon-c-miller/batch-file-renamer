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

        public void HandleSelection(int choice)
        {
            if (choice < 1 || choice > 4) return;

            switch (choice)
            {
                case 1:
                    ConsoleExtensions.YesOrNoPrompt(model.GetDisplayText(TextIDs.Option1Confirm));
                    break;

                case 2:
                    ConsoleExtensions.YesOrNoPrompt(model.GetDisplayText(TextIDs.Option2Confirm));
                    break;

                case 3:
                    ConsoleExtensions.YesOrNoPrompt(model.GetDisplayText(TextIDs.Option3Confirm));
                    break;
            }
        }
    }
}