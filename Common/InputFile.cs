using System.IO;

namespace Common
{
    public class InputFile
    {
        public static string[] ReadRows()
        {
            return File.ReadAllLines("input.txt");
        }

        public static string ReadInput()
        {
            return File.ReadAllText("input.txt").Trim();
        }
    }
}
