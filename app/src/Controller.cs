namespace ConsoleFileRenamer
{
    public class Controller : IRequestHandler
    {
        public Controller(IRequestReceiver requestReceiver)
        {
            this.requestReceiver = requestReceiver;
            view = new(this, model);
        }

        readonly IRequestReceiver requestReceiver;
        readonly Model model = new();
        readonly View view;

        public void IRelayRequest(RequestIDs id) => requestReceiver.IQueueRequest(id);

        public bool IHandleRequest(RequestIDs id, params object[] data)
        {
            switch (id)
            {
                case RequestIDs.PrintToConsole:
                    bool lineBefore = data.Length > 1 ? (bool)data[1] : false;
                    bool lineAfter = data.Length > 2 ? (bool)data[2] : false;
                    ConsoleExtensions.PrintToConsole((string)data[0], lineBefore, lineAfter);
                    break;
                
                case RequestIDs.ShowPrompt:
                    view.Prompt();
                    break;
                
                case RequestIDs.FilterMenuSelection:
                    int choice = data.Length > 0 ? (int)data[0] : 0;
                    bool choiceIsValid = view.HandleSelection(choice);
                    return choiceIsValid;
                
                case RequestIDs.YesOrNoQuestion:
                    lineBefore = data.Length > 1 ? (bool)data[1] : false;
                    bool yesOrNo = ConsoleExtensions.YesOrNoPrompt((string)data[0], lineBefore);
                    return yesOrNo;
            }

            return true;
        }
    }
}