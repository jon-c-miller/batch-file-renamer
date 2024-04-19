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

        public bool HandleSelection(int choice)
        {
            if (choice < 1 || choice > 4) return true;

            bool continueSelection = true;
            switch (choice)
            {
                case 1:
                    continueSelection = ConsoleExtensions.YesOrNoPrompt(model.GetDisplayText(TextIDs.QueryOption1Confirm));
                    break;

                case 2:
                    continueSelection = ConsoleExtensions.YesOrNoPrompt(model.GetDisplayText(TextIDs.QueryOption2Confirm));
                    break;

                case 3:
                    continueSelection = ConsoleExtensions.YesOrNoPrompt(model.GetDisplayText(TextIDs.QueryOption3Confirm));
                    break;

                case 4:
                    return !ConsoleExtensions.YesOrNoPrompt(model.GetDisplayText(TextIDs.QueryQuitConfirm));
            }

            if (continueSelection)
                continueSelection = ConsoleExtensions.YesOrNoPrompt(model.GetDisplayText(TextIDs.QueryConfirmCurrentDirectory), true);
            Console.ReadLine();

            return true;
        }
    }
}