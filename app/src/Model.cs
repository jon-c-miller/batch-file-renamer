namespace ConsoleFileRenamer
{
    public class Model
    {
        Dictionary<TextIDs, string> displayText = new()
        {
            { TextIDs.Welcome, "Welcome to the batch file renaming main menu! Please choose a style to get started."},
            { TextIDs.Header, "-- Renaming Styles --"},
            { TextIDs.Option1, "1. lowercase entire filename" },
            { TextIDs.Option2, "2. Capitalize First Letter Of Each Word In Filename" },
            { TextIDs.Option3, "3. UPPERCASE ENTIRE FILENAME" },
            { TextIDs.Quit, "4. Quit" },
            { TextIDs.OptionsPrompt, "Please choose a renaming style (1 - 3): "},
            { TextIDs.Option1Confirm, "Set the entire filename to lowercase? " },
            { TextIDs.Option2Confirm, "Capitalize the first letter of each word in the filename? " },
            { TextIDs.Option3Confirm, "Set the entire filename to uppercase? " },
            { TextIDs.QuitConfirm, "Quit application? "},
            { TextIDs.InvalidChoice, "is not a valid choice. "},
        };

        /// <summary> Get output text that matches id. </summary>
        public string GetDisplayText(TextIDs textID) => displayText.ContainsKey(textID) ? displayText[textID] : "";

        /// <summary> Get a list of options to create the main menu. </summary>
        public string GetMainMenuText()
        {
            var sb = new System.Text.StringBuilder();

            sb.Append($"{GetDisplayText(TextIDs.Welcome)}\n");
            sb.Append($"\n{GetDisplayText(TextIDs.Header)}");
            sb.Append($"\n{GetDisplayText(TextIDs.Option1)}");
            sb.Append($"\n{GetDisplayText(TextIDs.Option2)}");
            sb.Append($"\n{GetDisplayText(TextIDs.Option3)}");
            sb.Append($"\n{GetDisplayText(TextIDs.Quit)}\n");
            sb.Append($"\n{GetDisplayText(TextIDs.OptionsPrompt)}");
                
            return sb.ToString();
        }
    }

    public enum TextIDs
    {
        Welcome,
        Header,
        Option1,
        Option2,
        Option3,
        Quit,
        OptionsPrompt,
        Option1Confirm,
        Option2Confirm,
        Option3Confirm,
        QuitConfirm,
        InvalidChoice,
    }
}