﻿//srgjanx

namespace SRX.ViTool.Utils
{
    public class OrganizerArgs : IOrganizerArgs
    {
        public bool DatePrefix { get; private set; }
        public string ViberDirectory { get; private set; }
        public bool UseCurrentDir { get; set; }
        public bool DeletePTTDirectory { get; private set; }
        public bool DeleteTempDirectory { get; private set; }

        public OrganizerArgs(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                foreach (string arg in args)
                {
                    string argLower = arg.ToLower();
                    if (argLower.StartsWith("-dateprefix"))
                        DatePrefix = true;
                    if (argLower.StartsWith("-viberdir "))
                    {
                        ViberDirectory = arg.Remove(0, 10).TrimStart(' ');
                        ViberDirectory = ViberDirectory == string.Empty ? null : ViberDirectory;
                    }
                    if (argLower.StartsWith("-usecurrentdir"))
                        UseCurrentDir = true;
                    if(argLower.StartsWith("-deleteptt"))
                        DeletePTTDirectory = true;
                    if (argLower.StartsWith("-deletetemp"))
                        DeleteTempDirectory = true;
                }
            }
        }
    }
}