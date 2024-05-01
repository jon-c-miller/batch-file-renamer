public static class ConsoleExtensions
{
    /// <summary> Loop until the user provides one of a set of possible character choices. </summary>
    public static char CharChoicesPrompt(string promptText, bool endlineBefore = false, params char[] possibleChoices)
    {
        // end line when first entering the prompt if desired
        if (endlineBefore)
            Console.WriteLine();
        
        string? chosenChar;
        while (true)
        {
            Console.Write($"{promptText}");
            chosenChar = Console.ReadLine()?.ToUpper();

            // reject input over 1 character to prepare for parsing
            if (chosenChar?.Length > 1) continue;

            // examine the choice to see if it's one of the possible choices (failure to find will return -1)
            if (chosenChar?.IndexOfAny(possibleChoices) == 0)
                return char.Parse(chosenChar);
            else continue;
        }
    }

    /// <summary> Loop until the user inputs either y or n. </summary>
    public static bool YesOrNoPrompt(string promptText, bool endlineBefore = false)
    {
        // end line when first entering the prompt if desired
        if (endlineBefore)
            Console.WriteLine();

        string? continueChoice;
        while (true)
        {
            Console.Write($"{promptText}");
            continueChoice = Console.ReadLine()?.ToUpper();
            if (continueChoice == "N")
                return false;
            else if (continueChoice == "Y")
                return true;
            else continue;
        }
    }

    /// <summary> Wrap Console.Write() for ease of formatting line spacing before and after the message. </summary>
    public static void PrintToConsole(string message, bool endlineBefore = false, bool endlineAfter = false)
    {
        // print the given message with optional line spacing before and after
        if (endlineBefore)
            Console.WriteLine();

        Console.Write(message);

        if (endlineAfter)
            Console.WriteLine();
    }
}