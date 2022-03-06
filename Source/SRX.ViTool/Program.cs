//srgjanx

using System;
using System.IO;

namespace SRX.ViTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SRX Viber Organizer started!");
            Console.Write("-- -- -- -- --\n");
            //Get Viber directory from arguments if specified, else using Viber directory class.
            OrganizerArgs orgArgs = new OrganizerArgs(args);
            string viberDirectory = (!string.IsNullOrEmpty(orgArgs.ViberDirectory))
                ? orgArgs.ViberDirectory
                : new ViberDirectory().Get;
            //If the specified Viber directory does not exists, ask the user to enter it until he gives valid directory.
            while (!Directory.Exists(viberDirectory))
            {
                if (string.IsNullOrEmpty(viberDirectory))
                    Console.WriteLine("No viber directory found, please enter it yourself: ");
                else
                    Console.WriteLine($"The directory \"{viberDirectory}\" was not found, please enter it yourself: ");
                viberDirectory = Console.ReadLine();
            }
            //Continue to directory organization with the Viber directory specified.
            Console.WriteLine($"Using Viber directory \"{viberDirectory}\".");
            Organizer organizer = new Organizer(viberDirectory, orgArgs);
            try
            {
                organizer.Organize(out int? filesCount);
                if (filesCount.HasValue && filesCount.Value == 0)
                    Console.WriteLine("No files for organizing.");
                else
                    Console.WriteLine($"\n\nSuccessfully organized {filesCount} files!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred!\r\n{ex.Message}");
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n\n-- -- -- -- --");
            Console.ReadKey();
        }
    }
}