namespace ConsoleFileRenamer
{
    public class RequestHandler : IRequestHandler
    {
        public RequestHandler(IRequestReceiver requestReceiver)
        {
            this.requestReceiver = requestReceiver;
        }

        readonly IRequestReceiver requestReceiver;
        readonly Database database = new();

        public bool Continue { get; private set; } = true;

        bool isReady = false;

        public void Process()
        {
            if (isReady)
            {
                var input = Console.ReadLine();

                // filter out non-integer input
                if (!int.TryParse(input, out int choice)) return;

                // ignore invalid choice attempts
                if (choice < 1 || choice > 4) return;

                Continue = HandleSelection(choice);
            }
        }

        public void IHandleRequest(RequestIDs id, params object[] data)
        {
            switch (id)
            {
                case RequestIDs.DisplayMenu:
                    Operations.ClearConsole();
                    Operations.PrintToConsole(database.GetMainMenuText());
                    isReady = true;
                    break;
                
                case RequestIDs.DisplayCompletion:
                    Operations.PrintToConsole(database.GetDisplayText(TextIDs.PromptComplete), true);
                    Console.ReadLine();
                    break;
            }
        }

        bool HandleSelection(int choice)
        {
            // handle the main menu choices, including quit
            switch (choice)
            {
                case 1:
                    ConfirmOperation(OperationIDs.Lowercase, database.GetDisplayText(TextIDs.ConfirmOption1));
                    break;

                case 2:
                    ConfirmOperation(OperationIDs.CapitalizeFirst, database.GetDisplayText(TextIDs.ConfirmOption2));
                    break;

                case 3:
                    ConfirmOperation(OperationIDs.Uppercase, database.GetDisplayText(TextIDs.ConfirmOption3));
                    break;
                
                case 4:
                    return !Operations.YesOrNo(database.GetDisplayText(TextIDs.ConfirmQuit));
            }

            return true;
        }

        void ConfirmOperation(OperationIDs operation, string confirmText)
        {
            Operations.PrintToConsole(database.GetDisplayText(TextIDs.InfoCurrentDirectory), true);

            bool continueOperation = Operations.YesOrNo(confirmText, true);
            if (continueOperation)
            {
                // provide option to relocate or copy newly named files to new directory
                bool copyToNewDir = Operations.YesOrNo(database.GetDisplayText(TextIDs.ConfirmKeepOriginalFiles), true);

                // provide option to update space/symbol between words in filenames
                Symbols spaceBetweenSymbol = Symbols.Unmodified;
                bool changeSymbolBetweenWords = Operations.YesOrNo(database.GetDisplayText(TextIDs.ConfirmChangeSymbol), true);
                if (changeSymbolBetweenWords)
                    spaceBetweenSymbol = (Symbols)ConsoleExtensions.CharChoicesPrompt(database.GetDisplayText(TextIDs.PromptChooseSpacingSymbol), false, '_', '-', ' ');
                
                // show a list of operations to be completed
                Operations.ClearConsole();
                Operations.PrintToConsole(database.GetDisplayText(TextIDs.InfoRequestedChanges), false, true);

                if (copyToNewDir)
                    Operations.PrintToConsole(database.GetDisplayText(TextIDs.InfoCopy), true);
                else Operations.PrintToConsole(database.GetDisplayText(TextIDs.InfoMove), true);

                if (operation == OperationIDs.Lowercase)
                    Operations.PrintToConsole(database.GetDisplayText(TextIDs.InfoOption1Request), true);
                else if (operation == OperationIDs.CapitalizeFirst)
                    Operations.PrintToConsole(database.GetDisplayText(TextIDs.InfoOption2Request), true);
                else if (operation == OperationIDs.Uppercase)
                    Operations.PrintToConsole(database.GetDisplayText(TextIDs.InfoOption3Request), true);

                if (spaceBetweenSymbol != Symbols.Unmodified)
                    Operations.PrintToConsole(database.GetDisplayText(TextIDs.InfoSymbolReplacement) + $"'{(char)spaceBetweenSymbol}'", true);
                
                Operations.PrintToConsole("", true);

                // final confirmation
                if (continueOperation)
                    continueOperation = Operations.YesOrNo(database.GetDisplayText(TextIDs.ConfirmApplyChanges), true);
                
                if (continueOperation)
                {
                    isReady = false;
                    Operations.PrintToConsole(database.GetDisplayText(TextIDs.InfoExecuting), true, true);
                    Operations.Execute(operation, copyToNewDir, spaceBetweenSymbol);
                    requestReceiver.IQueueRequest(RequestIDs.DisplayCompletion);
                }
            }
            
            requestReceiver.IQueueRequest(RequestIDs.DisplayMenu);
        }
    }

    public enum OperationIDs
    {
        Lowercase,
        Uppercase,
        CapitalizeFirst,
        None,
    }

    public enum Symbols
    {
        Unmodified,
        Underscore = '_',
        Hyphen = '-',
        EmptySpace = ' ',
    }
}