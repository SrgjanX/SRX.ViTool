//srgjanx

namespace SRX.ViTool
{
    internal class OrganizerArgs
    {
        public bool DatePrefix { get; private set; } = true;
        public string ViberDirectory { get; private set; }

        public OrganizerArgs(string[] args)
        {
            if(args != null && args.Length > 0)
            {
                DatePrefix = false;
                foreach (string arg in args)
                {
                    if (arg == "-dateprefix")
                        DatePrefix = true;
                    if (arg.StartsWith("-viberdir "))
                        ViberDirectory = arg.Remove(0, 10);
                }
            }
        }
    }
}