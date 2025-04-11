using System.Collections.Concurrent;

namespace CodeChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OldPhoneUI phoneUI = new OldPhoneUI(new OldPhone());
            phoneUI.Start();
        }
    }
}
