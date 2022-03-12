//srgjanx

using System;
using System.Diagnostics;
using System.IO;
using SRX.ViTool.Utils;

namespace SRX.ViTool    
{
    internal class Program
    {
        private static string DefaultViberDirectory => $"C:\\Users\\{Environment.UserName}\\Documents\\ViberDownloads";

        private static void Main(string[] args)
        {
            PrintStatusMessage("ViTool started!");
            PrintStatusMessage("-- -- -- -- --\n");
            //Get organizer args from console args:
            IOrganizerArgs orgArgs = Factory.GetOrganizerArgs(args);
            //Get Viber directory from arguments if specified, otherwise from default directory:
            string viberDirectory = GetViberDirectory(orgArgs);
            //Continue to directory organization with the Viber directory specified.
            try
            {
                if (Directory.Exists(viberDirectory))
                {
                    PrintStatusMessage($"Using Viber directory \"{viberDirectory}\".");
                    IOrganizer organizer = Factory.GetOrganizer(viberDirectory, orgArgs);
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    organizer.Organize(out int? filesCount);
                    sw.Stop();
                    if (filesCount.HasValue && filesCount.Value == 0)
                        PrintStatusMessage("No files for organizing.");
                    else
                        PrintStatusMessage($"\nSuccessfully organized {filesCount} files in {sw.ElapsedMilliseconds}ms!", true);
                }
                else
                {
                    PrintStatusMessage($"Viber directory \"{viberDirectory}\" does not exists.", false);
                }
                
            }
            catch (Exception ex)
            {
                PrintStatusMessage($"Error occurred!\r\n{ex.Message}", false);
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n-- -- -- -- --");
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

        private static void PrintStatusMessage(string message, bool? status = null)
        {
            switch (status)
            {
                case true:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case false:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}