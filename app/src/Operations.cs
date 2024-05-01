namespace ConsoleFileRenamer
{
    public static class Operations
    {
        public static void Execute(OperationIDs operation, IRequestReceiver requestReceiver, bool copyToNewDir)
        {
            // create a new files directory to hold updated files
            var currentDirectory = Directory.GetCurrentDirectory();
            var updatedFilesDir = Path.Combine(currentDirectory, "updated files");
            if (!Directory.Exists(updatedFilesDir))
                Directory.CreateDirectory(updatedFilesDir);

            // get collection of full path of all files in current directory
            IEnumerable<string> allFiles = Directory.EnumerateFiles(currentDirectory, "*", SearchOption.TopDirectoryOnly);
            // string[] allFiles = Directory.GetFiles(currentDirectory);

            switch (operation)
            {
                case OperationIDs.Lowercase:
                    Lowercase(allFiles, updatedFilesDir, copyToNewDir);
                    break;

                case OperationIDs.CapitalizeFirst:
                    Capitalize(allFiles, updatedFilesDir, copyToNewDir);
                    break;

                case OperationIDs.Uppercase:
                    Uppercase(allFiles, updatedFilesDir, copyToNewDir);
                    break;
            }

            requestReceiver.IQueueRequest(RequestIDs.ChangeState, States.UserPrompt);
        }

        public static void ClearConsole() => Console.Clear();

        public static void PrintToConsole(string text, bool lineBefore = false, bool lineAfter = false) => ConsoleExtensions.PrintToConsole(text, lineBefore, lineAfter);

        public static bool YesOrNo(string text, bool lineBefore = false) => ConsoleExtensions.YesOrNoPrompt(text, lineBefore);

        static void Lowercase(IEnumerable<string> allFiles, string updatedFilesDir, bool copyToNewDir)
        {
            // copy the files in current directory to the updated files directory and lowercase the filenames
            foreach (var file in allFiles)
            {
                ExtractFilenameAndPath(file, out string originalFilename, out string originalFilePath);
                originalFilename = originalFilename.ToLower();
                MoveToDirectory(file, updatedFilesDir, originalFilename, copyToNewDir);
            }
        }

        static void Capitalize(IEnumerable<string> allFiles, string updatedFilesDir, bool copyToNewDir)
        {
            foreach (var file in allFiles)
            {
                ExtractFilenameAndPath(file, out string originalFilename, out string originalFilePath);

                // split the filename into words using space as the separator
                string[] filenameWords = originalFilename.Split(' ');

                // prepare a new container for the updated words
                string[] updatedFilenameWords = new string[filenameWords.Length];

                // loop through all of the words, changing their first letters to uppercase
                for (int i = 0; i < filenameWords.Length; i++)
                {
                    // convert the current word into a char array and update the first index to uppercase
                    char[] updatedWordChars = filenameWords[i].ToCharArray();
                    updatedWordChars[0] = char.ToUpper(updatedWordChars[0]);

                    // convert the char array back to a string and save it to the matching index in updated filenames
                    string updatedWord =  new(updatedWordChars);
                    updatedFilenameWords[i] = updatedWord;
                }

                // join the words back together into a filename
                originalFilename = String.Join(' ', updatedFilenameWords);

                MoveToDirectory(file, updatedFilesDir, originalFilename, copyToNewDir);
            }
        }

        static void Uppercase(IEnumerable<string> allFiles, string updatedFilesDir, bool copyToNewDir)
        {
            // copy the files in current directory to the updated files directory and uppercase the filenames
            foreach (var file in allFiles)
            {
                ExtractFilenameAndPath(file, out string originalFilename, out string originalFilePath);
                originalFilename = originalFilename.ToUpper();
                MoveToDirectory(file, updatedFilesDir, originalFilename, copyToNewDir);
            }
        }

        static void ExtractFilenameAndPath(string fullpath, out string fileName, out string filePath)
        {
            // loop backwards over the file entry (starting at the end after the extension) to get the filename
            fileName = "";
            filePath = "";
            for (int i = fullpath.Length - 1; i > 0; i--)
            {
                // parse backwards until the directory marker '/' or '\' is found
                if (fullpath[i] == '/' || fullpath[i] == '\\' )
                {
                    // extract the name of the file and its path (without filename)
                    fileName = fullpath.Substring(i + 1).Trim();
                    filePath = fullpath.Substring(0, i + 1);
                    break;
                }
            }

            PrintToConsole($"Found file to update: {fileName}", true);
        }

        static void MoveToDirectory(string filepath, string newDirectory, string newFilename, bool copyFiles)
        {
            // copy or move the files based on user selection
            string newPath = Path.Combine(newDirectory, newFilename);
            if (!File.Exists(newPath))
            {
                if (copyFiles)
                    File.Copy(filepath, newPath);
                else File.Move(filepath, newPath);
            }
            else PrintToConsole($"File '{newFilename}' already exists. Skipping...", true);
        }
    }
}