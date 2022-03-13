//srgjanx

using System;
using System.IO;

namespace SRX.ViTool.Utils
{
    public class Organizer : IOrganizer
    {
        private string dir;
        private IOrganizerArgs args;

        public Organizer(string dir, IOrganizerArgs args)
        {
            this.dir = dir;
            this.args = args;
        }

        public void Organize(out int? filesProcessedCount)
        {
            CheckIfDirectoryExists();

            string[] files = Directory.GetFiles(dir);

            ProcessFiles(files, out filesProcessedCount);
        }

        private void ProcessFiles(string[] files, out int? filesProcessedCount)
        {
            filesProcessedCount = null;
            if (files != null && files.Length > 0)
            {
                int length = files.Length;
                int skipped = 0;
                Console.WriteLine($"{length} files found!");
                for (int i = 0; i < length; i++)
                {
                    FileInfo fi = new FileInfo(files[i]);
                    try
                    {
                        DateTime dateModified = File.GetLastWriteTime(files[i]);
                        string dateDir = dir + "\\" + PrepareFolderName(dateModified);
                        if (!Directory.Exists(dateDir))
                            Directory.CreateDirectory(dateDir);
                        string newFile =
                            dateDir
                            + "\\"
                            + GetFileNamePrefix(dateModified)
                            + fi.Name;
                        File.Move(files[i], newFile);
                        Console.WriteLine($"[{i + 1}/{length}]   {fi.Name}");
                    }
                    catch (Exception ex)
                    {
                        Console.Write($"[{i + 1}/{length}]   {fi.Name}");
                        ConsoleEx.WriteLineStatus($" - skipped.\r\n{ex.Message}", false);
                        skipped++;
                    }
                }
                filesProcessedCount = length - skipped;
            }
        }

        private void CheckIfDirectoryExists()
        {
            if (!Directory.Exists(dir))
            {
                throw new DirectoryNotFoundException($"Directory \"{dir}\" not found.");
            }
        }

        /// <summary>
        /// Returns formatted folder name by given date time.
        /// </summary>
        private string PrepareFolderName(DateTime dt)
        {
            return dt.ToString("MM_yyyy");
        }

        private string GetFileNamePrefix(DateTime dt)
        {
            return args.DatePrefix
                ? dt.ToString("dd_MM_yyyy") + "_"
                : "";
        }
    }
}