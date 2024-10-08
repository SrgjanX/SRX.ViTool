﻿//srgjanx

using SRX.ViTool.Utils;
using System;
using System.Diagnostics;
using System.IO;

namespace SRX.ViTool
{
    internal class Program
    {
        private static string DefaultViberDirectory => $"C:\\Users\\{Environment.UserName}\\Documents\\ViberDownloads";

        private static void Main(string[] args)
        {
            ConsoleEx.WriteLine("ViTool started!");
            ConsoleEx.WriteLine("-- -- -- -- --\n");
            //Get organizer args from console args:
            IOrganizerArgs orgArgs = Factory.GetOrganizerArgs(args);
            //Get Viber directory from arguments if specified, otherwise from default directory:
            string viberDirectory = GetViberDirectory(orgArgs);
            //Continue to directory organization with the Viber directory specified.
            try
            {
                if (Directory.Exists(viberDirectory))
                {
                    ConsoleEx.WriteLine($"Using Viber directory \"{viberDirectory}\".");
                    IOrganizer organizer = Factory.GetOrganizer(viberDirectory, orgArgs);
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    organizer.Organize(out int? filesCount);
                    sw.Stop();
                    if ((filesCount ?? 0) == 0)
                        ConsoleEx.WriteLine("No files organized.");
                    else
                        ConsoleEx.WriteLine($"\nSuccessfully organized {filesCount} files in {sw.ElapsedMilliseconds}ms!", true);
                }
                else
                {
                    ConsoleEx.WriteLine($"Viber directory \"{viberDirectory}\" does not exists.", false);
                }
                
            }
            catch (Exception ex)
            {
                ConsoleEx.WriteLine($"Error occurred!\r\n{ex.Message}", false);
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
    }
}
