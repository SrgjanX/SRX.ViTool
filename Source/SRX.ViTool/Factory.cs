//srgjanx

namespace SRX.ViTool.Utils
{
    internal class Factory
    {
        internal static IOrganizerArgs GetOrganizerArgs(string[] args)
        {
            return new OrganizerArgs(args);
        }

        internal static IOrganizer GetOrganizer(string viberDirectory, IOrganizerArgs orgArgs)
        {
            return new Organizer(viberDirectory, orgArgs);
        }
    }
}