namespace ConsoleFileRenamer
{
    public class Model
    {
        Dictionary<OptionIDs, string> displayText = new()
        {
            { OptionIDs.Header, "-- Renaming Styles --"},
            { OptionIDs.Option1, "1. lowercase entire filename" },
            { OptionIDs.Option2, "2. Capitalize First Letter Of Each Word In Filename" },
            { OptionIDs.Option3, "3. UPPERCASE ENTIRE FILENAME" },
            { OptionIDs.OptionsPrompt, "Please choose a renaming style (1 - 3): "},
            { OptionIDs.Option1Confirm, "Set the entire filename to lowercase? " },
            { OptionIDs.Option2Confirm, "Capitalize the first letter of each word in the filename? " },
            { OptionIDs.Option3Confirm, "Set the entire filename to uppercase? " },
            { OptionIDs.InvalidChoice, "is not a valid choice. "},
        };

        /// <summary> Get output text that matches id. </summary>
        public string GetDisplayText(OptionIDs textID) => displayText.ContainsKey(textID) ? displayText[textID] : "";

        /// <summary> Get a list of options to create the main menu. </summary>
        public string GetMainMenuText()
        {
            var sb = new System.Text.StringBuilder();

            sb.Append($"\n{GetDisplayText(OptionIDs.Header)}");
            sb.Append($"\n{GetDisplayText(OptionIDs.Option1)}");
            sb.Append($"\n{GetDisplayText(OptionIDs.Option2)}");
            sb.Append($"\n{GetDisplayText(OptionIDs.Option3)}\n");
            sb.Append($"\n{GetDisplayText(OptionIDs.OptionsPrompt)}");
                
            return sb.ToString();
        }
    }

    public enum OptionIDs
    {
        Header,
        Option1,
        Option2,
        Option3,
        OptionsPrompt,
        Option1Confirm,
        Option2Confirm,
        Option3Confirm,
        InvalidChoice,
    }
}