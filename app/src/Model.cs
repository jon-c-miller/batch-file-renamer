namespace ConsoleFileRenamer
{
    public class Model
    {
        Dictionary<TextIDs, string> displayText = new()
        {
            { TextIDs.InfoWelcome, "Welcome to the batch file renaming main menu! Please choose a style to get started." },
            { TextIDs.InfoHeader, "-- Renaming Styles --" },
            { TextIDs.InfoOption1, "1. lowercase entire filename" },
            { TextIDs.InfoOption2, "2. Capitalize First Letter Of Each Word In Filename" },
            { TextIDs.InfoOption3, "3. UPPERCASE ENTIRE FILENAME" },
            { TextIDs.InfoQuit, "4. Quit" },
            { TextIDs.InfoInvalidChoice, "is not a valid choice. " },
            { TextIDs.InfoCurrentDirectory, $"Current directory is {Directory.GetCurrentDirectory()}. "},

            { TextIDs.PromptMainMenuOptions, "Please choose an option (1 - 4): " },

            { TextIDs.QueryOption1Confirm, "Set the entire filename to lowercase? (Y/N): " },
            { TextIDs.QueryOption2Confirm, "Capitalize the first letter of each word in the filename? (Y/N): " },
            { TextIDs.QueryOption3Confirm, "Set the entire filename to uppercase? (Y/N): " },
            { TextIDs.QueryQuitConfirm, "Quit application? (Y/N):  " },
            { TextIDs.QueryApplyToCurrentDirectory, $"Apply changes to files in current directory? (Y/N) " },
        };

        /// <summary> Get output text that matches id. </summary>
        public string GetDisplayText(TextIDs textID) => displayText.ContainsKey(textID) ? displayText[textID] : "";

        /// <summary> Get a list of options to create the main menu. </summary>
        public string GetMainMenuText()
        {
            var sb = new System.Text.StringBuilder();

            sb.Append($"{GetDisplayText(TextIDs.InfoWelcome)}\n");
            sb.Append($"\n{GetDisplayText(TextIDs.InfoHeader)}");
            sb.Append($"\n{GetDisplayText(TextIDs.InfoOption1)}");
            sb.Append($"\n{GetDisplayText(TextIDs.InfoOption2)}");
            sb.Append($"\n{GetDisplayText(TextIDs.InfoOption3)}");
            sb.Append($"\n{GetDisplayText(TextIDs.InfoQuit)}\n");
            sb.Append($"\n{GetDisplayText(TextIDs.PromptMainMenuOptions)}");
                
            return sb.ToString();
        }
    }

    public enum TextIDs
    {
        InfoWelcome,
        InfoHeader,
        InfoOption1,
        InfoOption2,
        InfoOption3,
        InfoQuit,
        InfoInvalidChoice,
        InfoCurrentDirectory,
        QueryApplyToCurrentDirectory,

        PromptMainMenuOptions,

        QueryOption1Confirm,
        QueryOption2Confirm,
        QueryOption3Confirm,
        QueryQuitConfirm,
        QueryGenericOK,
    }
}