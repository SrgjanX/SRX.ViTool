//srgjanx

using System;

namespace SRX.ViTool
{
    internal class ViberDirectory
    {
        public string Get
        {
            get
            {
                string userName = Environment.UserName;
                return $"C:\\Users\\{userName}\\Documents\\ViberDownloads";
            }
        }
    }
}