//srgjanx

namespace SRX.ViTool
{
    public class OrganizerArgs
    {
        public bool DatePrefix { get; private set; }
        public string ViberDirectory { get; private set; }

        public OrganizerArgs(string[] args)
        {
            if(args != null && args.Length > 0)
            {
                foreach (string arg in args)
                {
                    if (arg == "-dateprefix")
                        DatePrefix = true;
                    if (arg.StartsWith("-viberdir "))
                    {
                        ViberDirectory = arg.Remove(0, 10).TrimStart(' ');
                        ViberDirectory = ViberDirectory == string.Empty ? null : ViberDirectory;
                    }
                }
            }
        }
    }
}