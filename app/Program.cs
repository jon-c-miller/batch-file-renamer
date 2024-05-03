﻿using ConsoleFileRenamer;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Batch File Renaming Utility";

        new BatchFileRenamer().Run();

        Environment.Exit(0);
    }
}