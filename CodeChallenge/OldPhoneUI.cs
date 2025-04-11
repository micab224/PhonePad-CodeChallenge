using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    public class OldPhoneUI
    {
        private readonly OldPhone _oldPhone;

        public OldPhoneUI(OldPhone oldPhone)
        {
            _oldPhone = oldPhone;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the virtual phone keypad. Enter ## to finish.");
            bool cont = true;
            while (cont)
            {
                Console.WriteLine("Enter some numbers to translate: ");
                var input = Console.ReadLine();
                if (input == "##")
                {
                    cont = false;
                }
                else
                {
                    try
                    {
                        string result = OldPhone.OldPhonePad(input);
                        Console.WriteLine(result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    
                }
            }
            Console.WriteLine("See you!");
        }
    }
}
