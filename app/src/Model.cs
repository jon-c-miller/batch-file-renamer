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