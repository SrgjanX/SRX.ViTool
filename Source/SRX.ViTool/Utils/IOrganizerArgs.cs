//srgjanx

namespace SRX.ViTool.Utils
{
    public interface IOrganizerArgs
    {
        bool DatePrefix { get; }
        bool UseCurrentDir { get; set; }
        string ViberDirectory { get; }
    }
}