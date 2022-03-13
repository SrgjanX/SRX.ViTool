//srgjanx

using System;

namespace SRX.ViTool.Utils
{
    /// <summary>
    /// Console Extensions
    /// </summary>
    internal class ConsoleEx
    {
        public static void WriteLineStatus(string message, bool? status = null)
        {
            Console.ForegroundColor = status switch
            {
                true => ConsoleColor.Green,
                false => ConsoleColor.Red,
                _ => ConsoleColor.White,
            };
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}