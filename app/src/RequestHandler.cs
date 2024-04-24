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

        public bool Quit { get; private set; }
        string currentFilenameOld = "";
        string currentFilenameNew = "";

        States currentState = States.UserPrompt;
        OperationIDs currentOperation = OperationIDs.None;

        public void Process()
        {
            switch (currentState)
            {
                case States.UserPrompt:
                    Console.Clear();
                    PrintToConsole(database.GetMainMenuText());

                    var input = Console.ReadLine();

                    // filter out non-integer input
                    if (!int.TryParse(input, out int choice)) return;

                    // ignore invalid choice attempts
                    if (choice < 1 || choice > 4) return;

                    HandleSelection(choice);
                    break;

                case States.Processing:
                    break;
            }
        }

        public void IHandleRequest(RequestIDs id, params object[] data)
        {
            switch (id)
            {

            }
        }

        void PrintToConsole(string text, bool lineBefore = false, bool lineAfter = false) => ConsoleExtensions.PrintToConsole(text, lineBefore, lineAfter);

        bool YesOrNo(string text, bool lineBefore = false) => ConsoleExtensions.YesOrNoPrompt(text, lineBefore);

        bool HandleSelection(int choice)
        {
            // handle the main 3 choices or confirm quit
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
                    Quit = YesOrNo(database.GetDisplayText(TextIDs.ConfirmQuit));
                    break;
            }

            return true;
        }

        void ConfirmOperation(OperationIDs operation, string confirmText)
        {
            PrintToConsole(database.GetDisplayText(TextIDs.InfoCurrentDirectory), true);

            bool continueOperation = YesOrNo(confirmText, true);

            if (continueOperation)
                continueOperation = YesOrNo(database.GetDisplayText(TextIDs.ConfirmApplyChanges), true);
            
            if (continueOperation)
                ExecuteOperation(operation);
        }

        string ExtractFilename(string filepath)
        {
            // loop backwards over the file entry (starting at the end after the extension) to get the filename
            string filename = "";
            for (int i = filepath.Length - 1; i > 0; i--)
            {
                // parse backwards until the directory marker '/' or '\' is found
                if (filepath[i] == '/' || filepath[i] == '\\' )
                {
                    // extract the name of the file
                    filename = filepath.Substring(i + 1).Trim();
                    break;
                }
            }

            PrintToConsole($"Found file: {filename}", true);
            return filename;
        }

        void ExecuteOperation(OperationIDs operation)
        {
            currentState = States.Processing;
            PrintToConsole($"Executing operation {operation}...");
            Console.ReadLine();

            switch (operation)
            {
                case OperationIDs.Lowercase:
                    break;

                case OperationIDs.Uppercase:
                    break;

                case OperationIDs.CapitalizeFirst:
                    break;
            }

            PrintToConsole($"Updating file '{currentFilenameOld}' to '{currentFilenameNew}'...", true);
        }
    }
}