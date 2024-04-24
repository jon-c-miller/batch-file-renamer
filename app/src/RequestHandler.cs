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

        States currentState = States.UserPrompt;

        public void Process()
        {
            switch (currentState)
            {
                case States.UserPrompt:
                    Operations.ClearConsole();
                    Operations.PrintToConsole(database.GetMainMenuText());

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
                case RequestIDs.ChangeState:
                    ChangeState((States)data[0]);
                    break;
            }
        }

        void ChangeState(States newState)
        {
            currentState = newState;
        }

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
                    Quit = Operations.YesOrNo(database.GetDisplayText(TextIDs.ConfirmQuit));
                    break;
            }

            return true;
        }

        void ConfirmOperation(OperationIDs operation, string confirmText)
        {
            Operations.PrintToConsole(database.GetDisplayText(TextIDs.InfoCurrentDirectory), true);

            bool continueOperation = Operations.YesOrNo(confirmText, true);

            if (continueOperation)
                continueOperation = Operations.YesOrNo(database.GetDisplayText(TextIDs.ConfirmApplyChanges), true);
            
            if (continueOperation)
            {
                ChangeState(States.Processing);
                Operations.Execute(operation, requestReceiver);
            }
        }
    }
}