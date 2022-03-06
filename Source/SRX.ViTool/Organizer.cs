//srgjanx

using System;
using System.IO;

namespace SRX.ViTool
{
    internal class Organizer
    {
        private string dir;
        private OrganizerArgs args;

        public Organizer(string dir, OrganizerArgs args)
        {
            this.dir = dir;
            this.args = args;
        }

        public void Organize(out int? filesProcessedCount)
        {
            if (Directory.Exists(dir))
            {
                string[] files = Directory.GetFiles(dir);
                if (files != null && files.Length > 0)
                {
                    Console.Write("Processing . . . :");
                    foreach (string file in files)
                    {
                        //DateTime createdDate = File.GetCreationTime(file);
                        DateTime modDate = File.GetLastWriteTime(file);
                        string folder = dir + "\\" + PrepareFolderName(modDate);
                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);
                        FileInfo fi = new FileInfo(file);
                        string newFile = 
                            fi.Directory 
                            + "\\" 
                            + PrepareFolderName(modDate) 
                            + "\\" 
                            + GetFileNamePrefix(modDate) 
                            + fi.Name;
                        File.Move(file, newFile);
                        Console.Write(fi.Name + ", ");
                    }
                }
                //Console.WriteLine();
                filesProcessedCount = files.Length;
            }
            else
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