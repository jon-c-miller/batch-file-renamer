namespace ConsoleFileRenamer
{
    public class Database
    {
        Dictionary<TextIDs, string> displayText = new()
        {
            { TextIDs.InfoWelcome, "Welcome to the batch file renaming main menu! \nPlease choose a file naming style to get started." },
            { TextIDs.InfoHeader, "-- Available Options --" },
            { TextIDs.InfoOption1, "1. lowercase entire filename" },
            { TextIDs.InfoOption2, "2. Capitalize First Letter Of Each Word In Filename" },
            { TextIDs.InfoOption3, "3. UPPERCASE ENTIRE FILENAME" },
            { TextIDs.InfoQuit, "4. Quit" },
            { TextIDs.InfoInvalidChoice, "is not a valid choice. " },
            { TextIDs.InfoCurrentDirectory, $"Current directory is {Directory.GetCurrentDirectory()}. " },
            { TextIDs.InfoExecuting, "Executing operation..." },
            { TextIDs.InfoRequestedChanges, "-- Requested Operations --" },
            { TextIDs.InfoMove, "1. Move all files to /updated files" },
            { TextIDs.InfoCopy, "1. Copy all files to /updated files" },
            { TextIDs.InfoOption1Request, "2. Change filenames to lowercase (Original FilenamE >> original filename)" },
            { TextIDs.InfoOption2Request, "2. Capitalize filenames (Original FilenamE >> Original Filename)" },
            { TextIDs.InfoOption3Request, "2. Change filenames to uppercase (Original FilenamE >> ORIGINAL FILENAME)" },
            { TextIDs.InfoSymbolReplacement, "3. Replace any '_' and '-' characters, as well as empty spaces with " },


            { TextIDs.PromptMainMenuOptions, "Please choose an option (1 - 4): " },
            { TextIDs.PromptChooseSpacingSymbol, "Please choose a replacement symbol. (_/-/ ): " },
            { TextIDs.PromptComplete, "\nOperation completed. Press enter to return to main menu..." },

            { TextIDs.ConfirmOption1, "Update filenames in the current directory to be lowercase? (Y/N): " },
            { TextIDs.ConfirmOption2, "Update filenames in the current directory to have capitalized words? (Y/N): " },
            { TextIDs.ConfirmOption3, "Update filenames in the current directory to be uppercase? (Y/N): " },
            { TextIDs.ConfirmQuit, "Quit application? (Y/N): " },
            { TextIDs.ConfirmApplyChanges, "Apply requested filename changes? (Y/N): " },
            { TextIDs.ConfirmKeepOriginalFiles, "Newly named files will be created in '/updated files'. \nKeep original files (copy instead of move)? (Y/N): " },
            { TextIDs.ConfirmChangeSymbol, "The symbol between words in the filenames can also be updated. \nThis will replace all occurrences of _, -, and empty space characters with the symbol chosen in the next prompt. \nChange the symbol between words in the filenames? (Y/N): " }
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
        InfoRequestedChanges,
        InfoMove,
        InfoCopy,
        InfoOption1Request,
        InfoOption2Request,
        InfoOption3Request,
        InfoSymbolReplacement,
        InfoQuit,
        InfoInvalidChoice,
        InfoCurrentDirectory,
        InfoExecuting,

        PromptMainMenuOptions,
        PromptChooseSpacingSymbol,
        PromptComplete,

        ConfirmOption1,
        ConfirmOption2,
        ConfirmOption3,
        ConfirmKeepOriginalFiles,
        ConfirmChangeSymbol,
        ConfirmQuit,
        ConfirmApplyChanges,
    }
}