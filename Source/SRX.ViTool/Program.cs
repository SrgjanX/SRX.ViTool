//srgjanx

using System;
using System.IO;
using SRX.ViTool.Utils;

namespace SRX.ViTool
{
    internal class Program
    {
        private static string DefaultViberDirectory => $"C:\\Users\\{Environment.UserName}\\Documents\\ViberDownloads";

        private static void Main(string[] args)
        {
            Console.WriteLine("ViTool started!");
            Console.Write("-- -- -- -- --\n");
            //Get Viber directory from arguments if specified, else uses default Viber directory.
            IOrganizerArgs orgArgs = Factory.GetOrganizerArgs(args);
            string viberDirectory = GetViberDirectory(orgArgs);
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
            Console.WriteLine($"Using Viber directory \"{viberDirectory}\".\r\n");
            try
            {
                IOrganizer organizer = Factory.GetOrganizer(viberDirectory, orgArgs);
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
            finally
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n\n-- -- -- -- --");
                Console.WriteLine($"Press any key to close ViTool!");
                Console.ReadKey();
            }
        }

        private static string GetViberDirectory(IOrganizerArgs orgArgs)
        {
            if (!string.IsNullOrEmpty(orgArgs.ViberDirectory))
            {
                return orgArgs.ViberDirectory;
            }
            else if (orgArgs.UseCurrentDir)
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
            else
            {
                return DefaultViberDirectory;
            }
        }
    }
}